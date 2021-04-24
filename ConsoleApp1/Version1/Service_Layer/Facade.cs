using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Version1.DataAccessLayer;
using Version1.domainLayer;
using Version1.domainLayer.UserRoles;
using Version1.LogicLayer;

namespace Version1.Service_Layer
{
    public class Facade
    {
        private Logic logicInstance = new Logic();
        private SystemAdmin admin;
        private ShoppingHandler shoppingHandler = new ShoppingHandler();
        private StoreAdministration storeAdministration = new StoreAdministration();

        public bool testbool()
        {
            return true;
            
        }
        //high priority
        public bool Login(string username, string password)
        {
            return logicInstance.UserLogin(username,password);
        }
        //high priority
        public bool Register(string username, string password)
        {
            return logicInstance.Register(username,password);
        }
        //high priority
        public bool Logout(string userid)
        {
            return logicInstance.UserLogout(userid);
        }
        //high priority
        public string[][] GetAllProducts()
        {
            var inventory = logicInstance.GetInventory().Values.ToList();
            var allProducts = ProductsTo2DStringArray(inventory);
            return allProducts;
        }
        //high priority
        public string[][] getAllStores()
        {
        //    var result = StoresTo2DStringArray(logicInstance.GetAllStores());
        //    return result;
        throw new NotImplementedException();
        }
        //high priority
        public bool add_item_to_shop(string shopName, string itemBarCode, int amount)
        {
            throw new NotImplementedException();
        }
        //high priority
        public bool addItemToInventory(string itemBarCode, string itemName, int amount, int price, string shopName)
        {
            return logicInstance.AddItemToStore(shopName, itemBarCode, amount);
            
        }
        //high priority
        public string[][] get_items_in_shop(string shopName)
        {
            var products = logicInstance.GetProductsFromShop(shopName);
            if (products == null)
                return null;
            var result = ProductsTo2DStringArray(products.Keys.ToList());
            return result;
        }
        //high priority
        public string[][] SearchByKeyword(string keyword)
        {
            var productList = logicInstance.SearchByKeyWord(keyword);
            var result = ProductsTo2DStringArray(productList);
            
            return result;
        }
        //high priority
        public bool makeNewOwner(string apointerid, string storeName, string apointeeid)
        {
            throw new NotImplementedException();
        }

        //todo make sure that the each number of the permissions
        // appoint to different permission from a *table* of permissions.
        public bool makeNewManger(string apointerid, string storeName, string apointeeid, List<int> permissions)
        {
            throw new NotImplementedException();
        }

        public bool removeOwner(string apointerid, string storeName, string apointeeid)
        {
            throw new NotImplementedException();
        }

        public bool removeManager(string apointerid, string storeName, string apointeeid)
        {
            throw new NotImplementedException();
        }

        public bool addItemToCart(string username, string productBarCode, string storeName)
        {
            throw new NotImplementedException();
        }

        public int getCartId(string shopName, string userName)
        {
            throw new NotImplementedException();
        }

        public bool addPrudoctToCart(string shopName, string userName, string productBarCode)
        {
            throw new NotImplementedException();
        }
       

        public bool UpdateProduct(string name, string desc, string barcode, List<string> categories)
        {
            throw new NotImplementedException();
        }
        public bool DeleteProduct(string shopName, string userName, string productBarCode)
        {
            throw new NotImplementedException();
        }

        public bool OpenShop(string shopName, string userName)
        {
            throw new NotImplementedException();
        }

        public bool CloseShop(string shopName, string ownerName)
        {
            throw new NotImplementedException();
        }

        public bool HasPermission(string shopName, string userName, int permission)
        {
            throw new NotImplementedException();
        }

        public bool IsLogedIn(string userName)
        {
            throw new NotImplementedException();
        }

        public string[] getAllLogInUsersinSystem()
        {
            throw new NotImplementedException();
        }

        public string[] getAllCarts(string userName)
        {
            throw new NotImplementedException();
        }

        public int remove_item_from_cart(string productBarCode, int amount, string userName,string storeName)
        {
            throw new NotImplementedException();
        }
        public int isAdmin(string userName)
        {
            throw new NotImplementedException();
        }
        
        public int[] GetAppointmentPermissions(int shopid, int apointeeid)
        {
            throw new NotImplementedException();
        }

        public string[][] get_itmes_in_cart(int cartNum)
        {
            throw new NotImplementedException();
        }
        public string[][] get_all_items_in_all_carts(int userid)
        {
            throw new NotImplementedException();
        }

        public bool guestPurchaseProducts(string address, List<string> itemsBarCodes)
        {
            throw new NotImplementedException();
        }

        public bool Notification_Add(string userName, string msg)
        {
            throw new NotImplementedException();
        }
        public string[] Notification_GetAll(string userid)
        {
            throw new NotImplementedException();
        }
        
        public bool updatePurchasePolicy(string shopName, string policy)
        {
            throw new NotImplementedException();
        }
        //foreach shop get shopName and it's toString method
        public string[][] myShops(string userName)
        {
            throw new NotImplementedException();
        }

        public string[][] getItemsInfos()
        {
            throw new NotImplementedException();
        }
        
        public string getPurchasePolicy(string shopName)
        {
            throw new NotImplementedException();
        }

        private string[][] ProductsTo2DStringArray(List<Product> products)
        {
            var result = new string[products.Count][];
            var index = 0;
            foreach (var product in products)
            {
                var productData = new string[5];
                
                productData[0] = product.Name;
                productData[1] = product.Description;
                productData[2] = product.Barcode;
                productData[3] = product.Price.ToString(CultureInfo.CurrentCulture);

                var categories = "";
                foreach (var category in product.Categories)
                {
                    categories = categories + category.Name + "#";
                }
                productData[4] = categories;

                result[index] = productData;
                index += 1;
            }

            return result;
        }
        
        private string[][] StoresTo2DStringArray(List<Product> products)
        {
            var result = new string[products.Count][];
            var index = 0;
            foreach (var product in products)
            {
                var productData = new string[5];
                
                productData[0] = product.Name;
                productData[1] = product.Description;
                productData[2] = product.Barcode;
                productData[3] = product.Price.ToString(CultureInfo.CurrentCulture);

                var categories = "";
                foreach (var category in product.Categories)
                {
                    categories = categories + category.Name + "#";
                }
                productData[4] = categories;

                result[index] = productData;
                index += 1;
            }

            return result;
        }


        
    }
}
