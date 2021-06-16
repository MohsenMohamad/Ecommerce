using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Version1.DataAccessLayer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Version1.domainLayer.CompositeDP;
using Version1.domainLayer.StorePolicies;


namespace Version1.Service_Layer
{
    class Program
    {
        private static readonly string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public static void Main(string[] args)
        {
            /*var facade = new Facade();
            facade.AdminInitSystem();
            var result2 = facade.Purchase("adnan", "12341234", 11, 2030, "holder", 512, 208764533, "name", "address",
                "city",
                "country", 11);

            var store =DataHandler.Instance.GetStore("MohamedStore");
            var x = facade.GetStorePurchaseHistory(store.name);
            var v = facade.getStorePurchaseHistory("x",store.name);*/

            var and = new AndComposite();
            var or = new OrComposite();
            var and2 = new AndComposite();
            var policy = new MaxAmountPolicy("1", 3);
            var policy2 = new TimeRestrictedCategories(11, 15);
            var policy3 = new CustomerTypeRestriction();
            var policy4 = new MaxAmountPolicy("5", 11);
            policy3.AddRestrictedProduct("4");
            policy3.AddRestrictedProduct("5");
            policy2.AddRestrictedCategory("category1");
            policy2.AddRestrictedCategory("category2");
            and.Add(policy);
            and.Add(policy2);
            and2.Add(policy);
            and2.Add(policy4);
            or.Add(and);
            or.Add(and2);
            var js = new List<Component>();
            js.Add(and);
            js.Add(or);
            js.Add(and2);
            var json = JsonConvert.SerializeObject(js);
            
            File.WriteAllText(DesktopPath + @"\json\policy.json", json);

            Decrypt();


            //    Console.ReadKey();
        }

        private static void Decrypt()
        {
            var jsonString = File.ReadAllText(DesktopPath + @"\json\policy.json");
            var json = (JArray) JsonConvert.DeserializeObject(jsonString);

            var k = Rec(json, new AndComposite());

            //    var list = ((Composite)k)._children.ToList();

            //var isEqual = JsonConvert.SerializeObject(list).Equals(jsonString);


            Console.ReadKey();
        }

        private static Component Rec(JToken token, Component component)
        {
            if (token == null)
                return null;
            if (token.Type == JTokenType.Array)
            {
                foreach (var child in token)
                {
                    Rec(child, component);
                }

                return component;
            }

            var type = (string) token["Type"];
            if (type != "OR" && type != "AND")
            {
                var leaf = CreatePolicy(token);
                component.Add(leaf);
                return component;
            }

            if (type == "AND")
            {
                var and = new AndComposite();
                component.Add(Rec(token["Policies"], and));
                return and;
            }

            if (type == "OR")
            {
                var or = new OrComposite();
                component.Add(Rec(token["Policies"], or));
                return or;
            }

            return null;
        }

        private static Component CreatePolicy(JToken token)
        {
            var policyType = (string) token["Type"];
            switch (policyType)
            {
                case "Max Amount":
                {
                    var max = (int) token["MaxAmount"];
                    var barcode = (string) token["Barcode"];
                    return new MaxAmountPolicy(barcode, max);
                }
                case "Time":
                {
                    var hour = (int) token["Hour"];
                    var minute = (int) token["Minute"];
                    var categories = token["Categories"].ToArray();
                    var pol = new TimeRestrictedCategories(hour, minute);
                    foreach (var category in categories)
                    {
                        pol.AddRestrictedCategory((string) category);
                    }

                    return pol;
                }
                case "CustomerType":
                {
                    var pol = new CustomerTypeRestriction();
                    foreach (var barcode in token["Products"])
                    {
                        pol.AddRestrictedProduct((string) barcode);
                    }

                    return pol;
                }
                default:
                    return null;
            }
        }
        
    }
}