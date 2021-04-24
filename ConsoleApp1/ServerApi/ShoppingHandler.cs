using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Version1.Service_Layer;
using System.Web.Http.Cors;

namespace ServerApi
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    class ShoppingHandler
    {
        private Facade facade = new Facade();
        [HttpGet]
        public string[][] getAllProducts()
        {
            string[][] productsDummy = new string[4][];
                                                         //price
            string[] p1 = { "productName","descerption","barcode","19","catagory1#catagory2#catogory3#"};
            string[] p2 = { "shampoo","fine","55262623","15","hair#hands#"};
            string[] p3 = { "fairy","good","1595959","15","dish#"};
            string[] p4 = { "lab","high","1626256","15",""};
            productsDummy[0] = p1;
            productsDummy[1] = p2;
            productsDummy[2] = p3;
            productsDummy[3] = p4;
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
    }
}
