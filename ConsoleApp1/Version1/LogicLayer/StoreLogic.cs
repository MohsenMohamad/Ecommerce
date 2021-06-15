using System;
using System.Collections.Generic;
using System.Linq;
using Version1.DataAccessLayer;
using Version1.domainLayer;
using Version1.domainLayer.CompositeDP;
using Version1.domainLayer.DataStructures;
using Version1.domainLayer.DiscountPolicies;
using Version1.domainLayer.StorePolicies;

namespace Version1.LogicLayer
{
    public static class StoreLogic
    {
        public static bool OpenStore(string managerName, string storeName, string policy)
        {
            if (!DataHandler.Instance.Exists(managerName)) throw new Exception(Errors.UserNotFound);
            var store = new Store(managerName, storeName);
            var result = DataHandler.Instance.AddStore(store);
            if (!result)
                throw new Exception(Errors.StoreNameNotAvailable);
            return true;
        }

        public static bool AddProductToStore(string storeName, string barcode, string productName, string description,
            double price,
            List<string> categories, int amount)
        {

            var store = DataHandler.Instance.GetStore(storeName);
            if (store == null) throw new Exception(Errors.StoreNotFound);
            var exists = DataHandler.Instance.GetProduct(barcode, storeName) != null;
            if (exists) throw new Exception(Errors.ProductBarcodeNotAvailable);

            var product = new Product(barcode, productName, description, price, categories);
            if( store.GetInventory().TryAdd(product, amount))
            {
                database db = database.GetInstance();

                return db.InsertProductToStore(storeName,product, amount);
            }

            return false;
        }

        public static bool IsManger(string storeName, string mangerName)
        {
            if (!DataHandler.Instance.Stores.ContainsKey(storeName) ||
                !DataHandler.Instance.Stores[storeName].GetManagers().Contains(mangerName))
                return false;
            return true;
        }

        public static bool IsOwner(string storeName, string ownerName)
        {
            if (!DataHandler.Instance.Stores.ContainsKey(storeName) ||
                !DataHandler.Instance.Stores[storeName].GetOwners().Contains(ownerName))
                return false;
            return true;
        }

        public static bool UpdateProductAmountInStore(string userName, string storeName, string productBarcode,
            int amount)
        {
            lock (DataHandler.Instance.InefficientLock)
            {
                var user = DataHandler.Instance.GetUser(userName);
                if (user == null) throw new Exception(Errors.UserNotFound);
                var store = DataHandler.Instance.GetStore(storeName);
                if (store == null) throw new Exception(Errors.StoreNotFound);
                var product = DataHandler.Instance.GetProduct(productBarcode, storeName);
                if (product == null) throw new Exception(Errors.ProductNotFound);

                var inventory = store.GetInventory();
                if (!inventory.ContainsKey(product)) return false;
                inventory[product] = amount;
                return true;
            }
        }


        public static bool RemoveProductFromStore(string userName, string storeName, string productBarcode)
        {
            lock (DataHandler.Instance.InefficientLock)
            {
                var user = DataHandler.Instance.GetUser(userName);
                if (user == null) throw new Exception(Errors.UserNotFound);
                var store = DataHandler.Instance.GetStore(storeName);
                if (store == null) throw new Exception(Errors.StoreNotFound);
                var product = DataHandler.Instance.GetProduct(productBarcode, storeName);
                if (product == null) throw new Exception(Errors.ProductNotFound);

                var inventory = store.GetInventory();
                return inventory.ContainsKey(product) && inventory.TryRemove(product, out _);
            }
        }

        public static List<string> GetStoreOwners(string storeName)
        {
            var store = DataHandler.Instance.GetStore(storeName);
            return store?.GetOwners().ToList();
        }

        public static List<string> GetStoreManagers(string storeName)
        {
            var store = DataHandler.Instance.GetStore(storeName);
            return store?.GetManagers();
        }


        public static bool AddOwner(string storeName, string apointerid, string apointeeid)
        {
            var appointerUser = DataHandler.Instance.GetUser(apointerid);
            if (appointerUser == null) throw new Exception(Errors.UserNotFound);
            var newOwner = DataHandler.Instance.GetUser(apointeeid);
            if (newOwner == null) throw new Exception(Errors.UserNotFound);
            var store = DataHandler.Instance.GetStore(storeName);
            if (store == null) throw new Exception(Errors.StoreNotFound);

            if (!IsOwner(storeName, apointerid)) throw new Exception(Errors.PermissionError);
            if (IsOwner(storeName, apointeeid)) throw new Exception(Errors.AlreadyOwner);

            store.GetStaffTree().GetNode(apointerid).AddNode(apointeeid, -1);

            database.GetInstance().updateStoreStaff(storeName, store.GetStaffTree());
            return true;
        }

        public static bool AddManager(string storeName, string apointerid, string apointeeid, int permissions)
        {
            var appointerUser = DataHandler.Instance.GetUser(apointerid);
            if (appointerUser == null) throw new Exception(Errors.UserNotFound);
            var newManager = DataHandler.Instance.GetUser(apointeeid);
            if (newManager == null) throw new Exception(Errors.UserNotFound);
            var store = DataHandler.Instance.GetStore(storeName);
            if (store == null) throw new Exception(Errors.StoreNotFound);

            if (!IsOwner(storeName, apointerid)) throw new Exception(Errors.PermissionError);
            if (IsManger(storeName, apointeeid)) throw new Exception(Errors.AlreadyManager);

            store.GetStaffTree().GetNode(apointerid).AddNode(apointeeid, permissions);
            database.GetInstance().updateStoreStaff(storeName, store.GetStaffTree());
            return true;
        }

        public static bool RemoveOwner(string storeName, string firingUserName, string firedOwnerName)
        {
            var firedOwner = DataHandler.Instance.GetUser(firedOwnerName);
            if (firedOwner == null) throw new Exception(Errors.UserNotFound);
            var firingUser = DataHandler.Instance.GetUser(firingUserName);
            if (firingUser == null) throw new Exception(Errors.UserNotFound);
            var store = DataHandler.Instance.GetStore(storeName);
            if (store == null) throw new Exception(Errors.StoreNotFound);

            if (!IsOwner(storeName, firedOwnerName) || !IsOwner(storeName,firingUserName)) throw new Exception(Errors.NotAnOwner);

            if (!store.GetStaffTree().GetNode(firingUserName).IsParent(firedOwnerName)) throw new Exception(Errors.IllegalRemoveOwner);
            store.GetStaffTree().DeleteNode(firedOwnerName); // returns false if the owner was not found
            UserLogic.AddUserNotification(firedOwnerName, "You Are No Longer An Owner At " + storeName);
            database.GetInstance().updateStoreStaff(storeName, store.GetStaffTree());
            return true;
        }

        public static bool RemoveManager(string storeName, string username)
        {
            var manager = DataHandler.Instance.GetUser(username);
            if (manager == null) throw new Exception(Errors.UserNotFound);
            var store = DataHandler.Instance.GetStore(storeName);
            if (store == null) throw new Exception(Errors.StoreNotFound);

            var result = store.GetStaffTree().DeleteNode(username); // returns false if the manager was not found
            if (!result) throw new Exception(Errors.NotAManager);
            database.GetInstance().updateStoreStaff(storeName, store.GetStaffTree());
            return true;
        }

        private static bool IsValidPermission(int permissions)
        {
            return Permissions.IsValidPermission(permissions);
        }


//---------------------------------------- Getters ----------------------------------------//   

        public static List<Store> GetAllStores()
        {
            return DataHandler.Instance.Stores.Values.ToList();
        }

        public static List<Store> GetUserStores(string userName)
        {
            var stores = new List<Store>();
            if (DataHandler.Instance.GetUser(userName) == null)
                return null;

            foreach (var store in GetAllStores())
            {
                if (IsOwner(store.GetName(), userName) || IsManger(store.GetName(), userName))
                    stores.Add(store);
            }

            return stores;
        }


        public static string GetStorePolicy(string storeName)
        {
            var store = DataHandler.Instance.GetStore(storeName);
            return store?.GetPurchasePolicies().ToString();
        }

        public static List<string> GetStoresNames()
        {
            return DataHandler.Instance.Stores.Keys.ToList();
        }

        public static List<string> GetStorePurchaseHistory(string ownerUser, string storeName)
        {
            var store = DataHandler.Instance.GetStore(storeName);
            if (store == null) return null;
            var history = new List<string>();

            foreach (var purchase in store.GetHistory())
            {
                history.Add(purchase.ToString());
            }

            return history;
        }

        public static bool UpdateStorePolicy(string storeName, Component newPolicy)
        {
            var store = DataHandler.Instance.GetStore(storeName);
            if (store == null) return false;

            store.GetPurchasePolicies().Add(newPolicy);

            return true;
        }

        public static List<string> GetStoreProducts(string storeName)
        {
            var store = DataHandler.Instance.GetStore(storeName);

            return store?.GetInventory().Keys.Select(p => p.Barcode).ToList();
        }


        public static bool AddMaxProductPolicy(string storeName, string productBarCode, int amount)
        {
            var store = DataHandler.Instance.GetStore(storeName);
            if (store == null) throw new Exception(Errors.StoreNotFound);

            var product = DataHandler.Instance.GetProduct(productBarCode, storeName);
            if (product == null) throw new Exception(Errors.ProductNotFound);

            if (amount < 0) return false;


            var policy = new MaxAmountPolicy(productBarCode, amount);

            store.GetPurchasePolicies().Add(policy);

            return true;
        }

        public static bool AddCategoryPolicy(string storeName, string productCategory, int hour, int minute)
        {
            var store = DataHandler.Instance.GetStore(storeName);
            if (store == null) throw new Exception(Errors.StoreNotFound);

            var category = productCategory; // get category

            var policy = new TimeRestrictedCategories(hour, minute);
            policy.AddRestrictedCategory(category);

            store.GetPurchasePolicies().Add(policy);

            return true;
        }

        public static bool AddUserPolicy(string storeName, string productBarCode)
        {
            var store = DataHandler.Instance.GetStore(storeName);
            if (store == null) throw new Exception(Errors.StoreNotFound);

            var product = DataHandler.Instance.GetProduct(productBarCode, storeName);
            if (product == null) throw new Exception(Errors.ProductNotFound);

            var policy = new CustomerTypeRestriction();

            store.GetPurchasePolicies().Add(policy);

            return true;
        }

        public static bool AddCartPolicy(string storeName, int amount)
        {
            var store = DataHandler.Instance.GetStore(storeName);
            if (store == null) throw new Exception(Errors.StoreNotFound);


            if (amount < 0) return false;

            var policy = new MaxProductsInBasketPolicy(amount);

            store.GetPurchasePolicies().Add(policy);

            return true;
        }

        //todo
        public static bool CloseStore(string storeName, string ownerName)
        {
            var store = DataHandler.Instance.GetStore(storeName);
            if (store == null) throw new Exception(Errors.StoreNotFound);

            if (!store.GetOwner().Equals(ownerName)) throw new Exception(Errors.PermissionError);


            foreach (var guest in DataHandler.Instance.Guests.Values)
            {
                var closedStoreBasket = guest.GetShoppingCart().GetBasket(storeName);
                if (closedStoreBasket != null)
                    guest.GetShoppingCart().shoppingBaskets.Remove(storeName);
            }

            foreach (var user in DataHandler.Instance.Users.Values)
            {
                var closedStoreBasket = user.GetShoppingCart().GetBasket(storeName);
                if (closedStoreBasket != null)
                {
                    var basketInfo = CartLogic.GetBasketInfo(user.UserName, storeName);
                    user.GetShoppingCart().shoppingBaskets.Remove(storeName);
                    user.GetNotifications().Add("We are sorry to inform you that your cart from " + storeName +
                                                " has been deleted \n Basket Info :\n" + basketInfo);
                    database.GetInstance().updateNotification(user.UserName,user.GetNotifications());
                }
            }

            foreach (var manager in store.GetManagers())
            {
                var managerUser = DataHandler.Instance.GetUser(manager);
                ((User) managerUser).GetNotifications()
                    .Add(storeName + " has been closed , time to search for a new job");
                database.GetInstance().updateNotification(((User)managerUser).UserName, ((User)managerUser).GetNotifications());
            }

            foreach (var owner in store.GetOwners())
            {
                var ownerUser = DataHandler.Instance.GetUser(owner);
                ((User) ownerUser).GetNotifications()
                    .Add(storeName + " has been closed , time to search for a new job");
                database.GetInstance().updateNotification(((User)ownerUser).UserName, ((User)ownerUser).GetNotifications());
            }

            return DataHandler.Instance.Stores.TryRemove(storeName, out _);
        }
        
        /*public static int addPublicDiscount(string storeName, int percentage)
        {
            var store = DataHandler.Instance.GetStore(storeName);
            return store.addPublicDiscount(storeName, percentage);

        }*/

        public static int addPublicDiscount(string storeName, int percentage)
        {
            var store = DataHandler.Instance.GetStore(storeName);
            DtoPolicy discountPolicy = new DtoPolicy();

            foreach (var x in store.inventory)
            {
                x.Key.DiscountPolicy.DiscountDescription += string.Format(" discount {0}% off for all the shop", percentage);
                database.GetInstance().UpdateProductDiscountDiscreption(x.Key.barcode, x.Key.DiscountPolicy.DiscountDescription);
            }

            discountPolicy.SetPublic(percentage);
            discountPolicy.DiscountDescription = string.Format("discount {0}% off ", percentage);
            store.discountPolicies.Add(discountPolicy);
            database.GetInstance().AddDiscountToStore(storeName, discountPolicy);
            return 1;
        }

        public static int addPublicDiscount_toItem(string storeName, string barcode, int percentage)
        {
            var product = DataHandler.Instance.GetProduct(barcode, storeName);
            if (product.DiscountPolicy == null)
            {
                product.DiscountPolicy = new DtoPolicy();
            }

            product.DiscountPolicy.DiscountDescription += string.Format("discount {0}% off ", percentage);
            product.DiscountPolicy.Percentage = percentage;
            database.GetInstance().UpdateProductPolicy(product);
            return 1;
            
        }


        public static int addConditionalDiscount(string storeName, int percentage, string condition)
        {
            var store = DataHandler.Instance.GetStore(storeName);
            int res;
            try { Condition.Parse(condition); }
            catch (Exception e) { return -13; }
            DtoPolicy p = new DtoPolicy();

            if ((res = p.SetConditional(percentage, condition)) < 0)
                return res;
            foreach (var x in store.inventory)
            {
                x.Key.DiscountPolicy.DiscountDescription += string.Format("# discount {0} % off for if the condition : {1} accomplish#", percentage,Condition.Parse(condition).get_description());
                database.GetInstance().UpdateProductDiscountDiscreption(x.Key.barcode, x.Key.DiscountPolicy.DiscountDescription);
            }
            DtoPolicy discountPolicy = new DtoPolicy();
            discountPolicy.SetConditional(percentage, condition);
            store.discountPolicies.Add(discountPolicy);
            database.GetInstance().AddDiscountToStore(storeName, discountPolicy);
            return res;
        }
        
        public static double GetTotalCart(string userName)
        {
            double a = 0;
            
            if (DataHandler.Instance.Users.ContainsKey(userName))
            {
                User user = DataHandler.Instance.Users[userName];
                ShoppingCart shcart = user.shoppingCart;
                
                foreach (KeyValuePair<string, ShoppingBasket> entry in shcart.shoppingBaskets)
                {
                    string storeName = entry.Key;
                    Store store = DataHandler.Instance.GetStore(storeName);
                    //DTO_Policies shop_policy = store.discountPolicy;
                    
                    foreach (KeyValuePair<string, int> pro in entry.Value.Products)
                    {
                        Product product = DataHandler.Instance.GetProduct(pro.Key, storeName);
                        //there are no bid for the item
                        if (user.GetShoppingCart().GetBasket(storeName).priceperproduct[pro.Key] == product.Price * pro.Value)
                        {
                            
                            double totalDiscount = 0;

                            if (store.discountPolicies != null)
                            {
                                foreach (DtoPolicy shop_policy in store.discountPolicies)
                                {
                                    DiscountPolicy discountPolicy = DiscountPolicy.GetPolicy(shop_policy);
                                    //adding all the shop discount
                                    if ((shop_policy.TypeOfPolicy == 1 || shop_policy.TypeOfPolicy == 2))
                                    {
                                        totalDiscount += discountPolicy.GetTotal(shcart, user, product, pro.Value);
                                    }
                                    //adding all the product discount
                                }
                            }



                            DtoPolicy itemPolicy = product.DiscountPolicy;
                            if (itemPolicy != null)
                            {
                                //discountPolicy = DiscountPolicy.GetPolicy(item_policy);

                                //totalDiscount += discountPolicy.getTotal(shcart, user, product, pro.Value);
                                totalDiscount += itemPolicy.Percentage;

                            }

                            totalDiscount = Math.Min(100, totalDiscount);
                            a += ((product.Price * (100 - totalDiscount)) / 100) * pro.Value;
                        }
                        //there are bid for the item
                        else
                        {
                            //here the price after the offer is multiplied with the amount 
                            a += user.GetShoppingCart().GetBasket(storeName).priceperproduct[pro.Key];
                        }
                        
                    }
                }
                return a;
            }
            else
            {
                return -1;
            }
            
            
        }
        
        
        public static List<string> GetStorePurchaseHistory(string storeName)
        {
            lock (DataHandler.Instance.InefficientLock)
            {

                var store = DataHandler.Instance.GetStore(storeName);
                if (store == null) throw new Exception(Errors.StoreNotFound);
                
                var historyList = store.history.Select(purchaseData => purchaseData.ToString()).ToList();

                return historyList;
            }
        }

    }
}