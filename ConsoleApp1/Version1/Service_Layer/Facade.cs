using System;
using System.Collections.Generic;
using Version1.DataAccessLayer;
using Version1.domainLayer.UserRoles;
using Version1.LogicLayer;

namespace Version1.presentationLayer
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
        public bool login(string username, string password)
        {
            throw new NotImplementedException();
        }
        //high priority
        public bool Register(string username, string password)
        {
            throw new NotImplementedException();
        }
        //high priority
        public bool Logout(string userid)
        {
            throw new NotImplementedException();
        }
        //high priority
        public string[][] getAllProducts()
        {
            throw new NotImplementedException();
        }
        //high priority
        public string[][] getAllStores()
        {
            throw new NotImplementedException();
        }
        //high priority
        public bool add_item_to_shop(string itemBarCode, string item_name, int amount, int price, string shopName)
        {
            throw new NotImplementedException();
        }
        //high priority
        public string[][] get_items_in_shop(string shopName)
        {
            throw new NotImplementedException();
        }
        //high priority
        public string[][] search(string keyword)
        {
            throw new NotImplementedException();
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
        

    }
}
