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
        public string[][] getAllProducts()
        {
                                                         //price
            string[] p1 = { "productName","descerption","barcode","price","catagory1#catagory2#catogory3#"};
            string[] p2 = { "bestCleaner","fine","55262623","15","hair#hands#"};
            string[] p3 = { "fairy","good","1595959","15","dish#"};
            string[] p4 = { "lab","high","1626256","15",""};
            string[][] productsDummy = { p1, p2, p3, p4 };
            return productsDummy;
            //return facade.getAllProducts();
        }
        [HttpGet]
        public string[][] getAllStores()
        {
            string[][]storesDummy = new string[3][];
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
            return storesDummy;
            //return facade.getAllStores();
        }
        [HttpGet]
        public bool addItemToStore(string itemBarCode, string item_name, int amount, int price, string shopName)
        {
            if (facade.AddNewProductToSystem(itemBarCode, item_name, amount, price, shopName))
            {
                return facade.AddItemToStore(shopName,itemBarCode,amount);    
            }
            //the item barcode does not match the ProductName in the inventory. 
            return false;
        }
        [HttpGet]
        public string[][] search(string keyword)
        {
            return facade.SearchByKeyword(keyword);
        }
        [HttpGet]
        public bool makeNewOwner(string apointerid, string storeName, string apointeeid)
        {
            return facade.makeNewOwner(apointerid,storeName,apointeeid);
        }
        [HttpGet]
        public bool makeNewManger(string apointerid, string storeName, string apointeeid, List<int> permissions)
        {   //todo split the permissions and make dataStructures that saves the permissions
            return facade.makeNewManger(apointerid,storeName,apointeeid,permissions);
        }
        [HttpGet]
        public bool removeOwner(string apointerid, string storeName, string apointeeid)
        {
            return facade.removeOwner(apointerid,storeName,apointeeid);
        }
        [HttpGet]
        public bool removeManager(string apointerid, string storeName, string apointeeid)
        {
            return facade.removeManager(apointerid,storeName,apointeeid);
        }
        [HttpGet]
        public bool addItemToCart(string username, string productBarCode, string storeName)
        {
            return facade.addItemToCart(username,productBarCode,storeName);
        }
        
        
        
    }
}
