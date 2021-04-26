using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

using System.Web.Http.Cors;
using Version1.Service_Layer;

namespace ServerApi
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ShopServiceController : ApiController
    {
        private Facade facade = new Facade();
        [HttpGet]
        public string[][] GetStoresProducts()
        {
            //price
        /*    string[] p1 = { "productName", "descerption", "barcode", "price", "catagory1#catagory2#catogory3#", "shop1" };
            string[] p2 = { "bestCleaner", "fine", "55262623", "15", "hair#hands#", "shop2" };
            string[] p3 = { "fairy", "good", "1595959", "15", "dish#", "shop3" };
            string[] p4 = { "lab", "high", "1626256", "15", "", "shop4" };
            string[][] productsDummy = { p1, p2, p3, p4 };
            return productsDummy;*/
            var a = facade.GetStoresProducts();
            return a;
        }
        [HttpGet]
        public string[][] getAllStores()
        {
/*            string[][]storesDummy = new string[3][];
            string[] s1 = { "storeName","ownerName","sellingpolicy","message1#message2#message3#",
                "paymentInfo1#paymentInfo2#","manger1#manger2#",
                "coOwner1#coOwner2#","discount1#discount2#","historyLogger","inventoryProduct1#inventoryProduct2#"};
            string[] s2 = { "amazon","shady","sellingpolicy","shadylogedIn#",
                "paymentInfo1#","eran#yara#",
                "adnan#","30%#10%#","historyLogger","shampoo#lab#"};
            string[] s3 = { "ebay","ossama","sellingpolicy","",
                "paymentInfo1#","ossama#mohsen#",
                "adnan#","30%#","historyLogger","fairy#"};
            storesDummy[0] = s1;
            storesDummy[1] = s2;
            storesDummy[2] = s3;
            return storesDummy;*/
            return facade.GetAllStores();
        }
        [HttpGet]
        public bool addItemToStore(string itemBarCode, string item_name, int amount, int price, string shopName,string descreption,string[] catagories)
        {   //todo check if works from mohsen!
            if (facade.AddNewProductToSystem(itemBarCode, item_name, descreption, price, catagories))
            {
                return facade.AddItemToStore(shopName,itemBarCode,amount);    
            }
            //the item barcode does not match the ProductName in the inventory. 
            return false;
        }

        [HttpGet]
        public string[][] GetUserBaskets(string userName)
        {
            return facade.GetUserBaskets(userName);
        }

        [HttpGet]
        public bool OpenShop(string userName, string shopName, string policy)
        {
            return facade.OpenShop(userName , shopName, policy);
        }

        [HttpGet]
        public string[][] search(string keyword)
        {
            return facade.SearchByKeyword(keyword);
        }
        [HttpGet]
        public bool makeNewOwner(string apointerid, string storeName, string apointeeid)
        {
            return facade.MakeNewOwner(apointerid,storeName,apointeeid);
        }
        [HttpGet]
        public bool makeNewManger(string apointerid, string storeName, string apointeeid, List<int> permissions)
        {   //todo split the permissions and make dataStructures that saves the permissions
            return facade.MakeNewManger(apointerid,storeName,apointeeid,permissions);
        }
        [HttpGet]
        public bool removeOwner(string apointerid, string storeName, string apointeeid)
        {
            return facade.RemoveOwner(apointerid,storeName,apointeeid);
        }
        [HttpGet]
        public bool removeManager(string apointerid, string storeName, string apointeeid)
        {
            return facade.RemoveManager(apointerid,storeName,apointeeid);
        }
        [HttpGet]
        public bool AddProductToBasket(string userName, string storeName, string productBarCode,int amount)
        {
            return facade.AddProductToBasket(userName, storeName, productBarCode, amount);

        }
        [HttpGet]
        public string[][] GetUserStores(string userName)
        {
            return facade.GetUserStores(userName);
         
        }


    }
}
