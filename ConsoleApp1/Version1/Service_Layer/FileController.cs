using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Version1.Service_Layer
{
    public class FileController
    {
        private static readonly string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private const string FacadeName = "Facade";

        public static void Test()
        {
            CreateJson();
            ReadStateFile("");
        }

        public static bool ReadStateFile(string path)
        {
            // wrap all this in try and different catches

            // check if class is facade for security reasons

            var jsonString = File.ReadAllText(path);
          // var jsonString = File.ReadAllText(DesktopPath + @"\json\file.json");
            var jsonArray = (JArray) JsonConvert.DeserializeObject(jsonString);

            foreach (var token in jsonArray)
            {
                var json = (JObject) token;

                var type = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .First(t => t.Name == (string) json["Class"]);

                var inst = Activator.CreateInstance(type);
                var method = type.GetMethod((string) json["Method"]);
                var parameters = method.GetParameters()
                    .Select(p => Convert.ChangeType((string) json["Params"][p.Position], p.ParameterType))
                    .ToArray();
                var result = method.Invoke(inst, parameters); // check if null or false
            }
            return true;
        }

        private static void CreateJson()
        {
            var js = new List<FileData>();
            js.Add(new FileData()
            {
                ClassName = FacadeName,
                MethodName = "Register",
                MethodParams = new List<string> {"dsa", "321"}
            });

            js.Add(new FileData()
            {
                ClassName = FacadeName,
                MethodName = "Register",
                MethodParams = new List<string> {"yy", "zz"}
            });

            var json = JsonConvert.SerializeObject(js);

            File.WriteAllText(DesktopPath + @"\json\file.json", json);
        }

        [Serializable]
        private class FileData : ISerializable
        {
            protected internal string ClassName;
            protected internal string MethodName;
            protected internal List<string> MethodParams;

            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("Class", ClassName);
                info.AddValue("Method", MethodName);
                info.AddValue("Params", MethodParams);
            }
        }
    }
}