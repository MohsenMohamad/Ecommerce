using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Version1.domainLayer.DataStructures;

namespace Version1.Service_Layer
{
    public class FileController
    {
        private static readonly string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        private static readonly Type FacadeType =
            Assembly.GetExecutingAssembly().GetTypes().First(t => t.Name == "Facade");

        public static void Test()
        {
            //CreateJson();
            ReadStateFile(DesktopPath + @"\json\file.json");
            Console.ReadKey();
        }

        public static bool ReadStateFile(string path)
        {
            // wrap all this in try and different catches
            
          /*  try
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
*/
            return true;
        }

      /*  private static void CreateJson()
        {
            
            var electronics = new Category("Electronics");
            var fashion = new Category("Fashion");
            var health = new Category("Health");
            var beauty = new Category("Beauty");
            var sports = new Category("Sports");
            var arts = new Category("Arts");
            
            var product1 = new Product("1", "camera", "Sony Alpha a7 III Mirrorless Digital Camera Body - ILCE7M3/B",
                800,
                new[] { electronics.Name }.ToList());
            var product2 = new Product("2", "women shoes",
                "Nike React Element 55 Women’s Running Shoes Grey Purple Blue Size 11 BQ2728-008.", 450,
                new[] { fashion.Name, sports.Name }.ToList());
            var product3 = new Product("3", "shampo keef", "shampo", 25, new[] { beauty.Name }.ToList());
            var product4 = new Product("4", "hand cream", "hand cream with good smell", 50,
                new[] { health.Name, beauty.Name }.ToList());
            var product5 = new Product("5", "sandals", "comfortable sandals", 349.99,
                new[] { fashion.Name, health.Name, sports.Name }.ToList());
            var product6 = new Product("6", "brush", "just a normal brush  what did you expect ...", 33,
                new[] { arts.Name }.ToList());
            
            var js = new List<FileData>
            {
                *//* ----------------------------  Users -------------------------------*//*
                new FileData() {MethodName = "Register", MethodParams = new List<string> {"mohamedm", "1111"}},
                new FileData() {MethodName = "Register", MethodParams = new List<string> {"adnan", "2222"}},
                new FileData() {MethodName = "Register", MethodParams = new List<string> {"mohameda", "3333"}},
                new FileData() {MethodName = "Register", MethodParams = new List<string> {"yara", "4444"}},
                new FileData() {MethodName = "Register", MethodParams = new List<string> {"shadi", "5555"}},
                new FileData() {MethodName = "Register", MethodParams = new List<string> {"asd", "123"}},
                
                *//* ----------------------------- Stores ---------------------------------*//*

                
                new FileData() {MethodName = "OpenStore", MethodParams = new List<string> {"mohamedm", "MohamedStore", "MohamedPolicy"}},
                new FileData() {MethodName = "MakeNewManger", MethodParams = new List<string> {"MohamedStore", "mohamedm", "yara", "4"}},
                new FileData() {MethodName = "AddProductToStore", MethodParams = new List<string> {"mohamedm", "MohamedStore", product3.Barcode, product3.Name, product3.Description,
                    product3.Price.ToString(CultureInfo.CurrentCulture), product3.Categories[0], "8"}},
                new FileData() {MethodName = "AddProductToStore", MethodParams = new List<string> {"mohamedm", "MohamedStore", product1.Barcode, product1.Name, product1.Description,
                    product1.Price.ToString(CultureInfo.CurrentCulture), product1.Categories[0], "11"}},
                new FileData() {MethodName = "AddProductToStore", MethodParams = new List<string> {"mohamedm", "MohamedStore", product6.Barcode, product6.Name, product6.Description,
                    product6.Price.ToString(CultureInfo.CurrentCulture), product6.Categories[0], "20"}},
                
                
                new FileData() {MethodName = "OpenStore", MethodParams = new List<string> {"adnan", "AdnanStore", "AdnanPolicy"}},
                new FileData() {MethodName = "MakeNewManger", MethodParams = new List<string> {"AdnanStore", "adnan", "shadi", "1"}},
                new FileData() {MethodName = "MakeNewOwner", MethodParams = new List<string> {"AdnanStore", "adnan", "yara"}},
                new FileData() {MethodName = "AddProductToStore", MethodParams = new List<string> {"adnan", "AdnanStore", product2.Barcode, product2.Name, product2.Description,
                    product2.Price.ToString(CultureInfo.CurrentCulture), product2.Categories[0] + "#" + product2.Categories[1], "18"}},
                new FileData() {MethodName = "AddProductToStore", MethodParams = new List<string> {"adnan", "AdnanStore", product4.Barcode, product4.Name, product4.Description,
                    product4.Price.ToString(CultureInfo.CurrentCulture), product4.Categories[0] + "#" + product4.Categories[1], "20"}},
                new FileData() {MethodName = "AddProductToStore", MethodParams = new List<string> {"adnan", "AdnanStore", product5.Barcode, product5.Name, product5.Description,
                    product5.Price.ToString(CultureInfo.CurrentCulture), product5.Categories[0] + "#" + product5.Categories[1] + "#" + product5.Categories[2], "7"}},
                
                
                new FileData() {MethodName = "AddProductToBasket", MethodParams = new List<string> {"mohameda", "AdnanStore", "5", "3", "349.99"}},
                new FileData() {MethodName = "AddProductToBasket", MethodParams = new List<string> {"mohameda", "AdnanStore", "2", "4", "450"}},
                new FileData() {MethodName = "AddProductToBasket", MethodParams = new List<string> {"adnan", "MohamedStore", "1", "2", "800"}},
                new FileData() {MethodName = "AddProductToBasket", MethodParams = new List<string> {"yara", "MohamedStore", "5", "1", "349.99"}},
                new FileData() {MethodName = "AddProductToBasket", MethodParams = new List<string> {"shadi", "AdnanStore", "4", "10", "50"}},
                

};
            var json = JsonConvert.SerializeObject(js);
            try
            {
                File.WriteAllText(DesktopPath + @"\json\file.json", json);
            }
            catch
            {
                (new FileInfo(DesktopPath + @"\json\file.json")).Directory.Create();
                File.WriteAllText(DesktopPath + @"\json\file.json", json);
            }
            
        }*/

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