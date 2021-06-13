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

        private static readonly Type FacadeType =
            Assembly.GetExecutingAssembly().GetTypes().First(t => t.Name == "Facade");

        public static void Test()
        {
            CreateJson();
            ReadStateFile(DesktopPath + @"\json\file.json");
        }

        public static bool ReadStateFile(string path)
        {
            // wrap all this in try and different catches
            
            try
            {
                var jsonString = File.ReadAllText(path);
                var jsonArray = (JArray) JsonConvert.DeserializeObject(jsonString);

                if (jsonArray == null) return false; // check 1

                var tokenIndex = 0;

                foreach (var token in jsonArray)
                {
                    var json = (JObject) token;

                    if (json.Count != 2)
                        throw new Exception("Error : Illegal number of elements at json object num " + tokenIndex);
                    
                    var methodName = (string) json["Method"];
                    var methodParams = json["Params"];

                    if (methodName == null || methodParams == null) throw new Exception("Wrong State File Format"); // check 2

                    var inst = Activator.CreateInstance(FacadeType);
                    var method = FacadeType.GetMethod(methodName);

                    if (method == null) throw new Exception("Error : the method " + methodName + " is not supported");

                    if (method.GetParameters().Length != methodParams.ToArray().Length)
                        throw new Exception("Error : Illegal Params number for " + methodName);
                    var parameters = method.GetParameters()
                        .Select(p => Convert.ChangeType((string) methodParams[p.Position], p.ParameterType))
                        .ToArray();
                    var result = method.Invoke(inst, parameters); // check if null or false

                    switch (result)
                    {
                        case bool b when !b:
                            throw new Exception("Error : " + methodName + "Returned False!");
                        case null:
                            throw new Exception("Error : " + methodName + "Returned Null!");
                    }

                    tokenIndex++;
                }
            }
            catch (TargetInvocationException targetException)
            {
                if (targetException.InnerException != null)
                    throw targetException.InnerException;
                throw;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return true;
        }

        private static void CreateJson()
        {
            var js = new List<FileData>
            {
                new FileData() {MethodName = "Register", MethodParams = new List<string> {"dsa", "321"}},
                new FileData() {MethodName = "Register", MethodParams = new List<string> {"yy", "zz"}},
                new FileData() {MethodName = "OpenStore", MethodParams = new List<string> {"yy", "yyStore", "stam"}}
            };

            var json = JsonConvert.SerializeObject(js);

            File.WriteAllText(DesktopPath + @"\json\file.json", json);
        }

        [Serializable]
        private class FileData : ISerializable
        {
            protected internal string MethodName;
            protected internal List<string> MethodParams;

            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("Method", MethodName);
                info.AddValue("Params", MethodParams);
            }
        }
    }
}