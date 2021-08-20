using System.Linq;
using NUnit.Framework;
using ServiceLogic.DataAccessLayer.DataStructures;
using ServiceLogic.DomainLayer.StoreFeatures.StorePolicies;
using ServiceLogic.DomainLayer.StoreFeatures.StorePolicies.CompositeDP;
using ServiceLogic.Service_Layer;

namespace TestProject.StorePoliciesTests
{
    public class CompositePolicyTest : ATProject
    {
        private const string OwnerName = "adnan";
        private const string StoreName = "AdnanStore";
        private const string UserName = "k";
        private const string Password = "zz";
        private static Category electronics = new Category("Electronics");
        private Product product1 = new Product("1", "camera", "Sony Alpha a7 III Mirrorless Digital Camera Body - ILCE7M3/B",
            800,
            new[] {electronics.Name}.ToList());

        [OneTimeSetUp]
        public void SetUp()
        {

            AdminInitiateSystem();
            
            Register(UserName, Password);

            AddProductToStore(OwnerName, StoreName,product1.Barcode,product1.Name,product1.Description,product1.Price,product1.Categories.ToString(),10);

        }

        [Test]
        public void Normal()
        {
            var basketPolicy = new MaxProductsInBasketPolicy(1);
            UpdatePurchasePolicy(StoreName, basketPolicy);

            AddProductToCart(UserName, StoreName, product1.Barcode,2, product1.price);
            Assert.True(ValidateBasketPolicies(UserName,StoreName));
        }

        [Test]
        public void And()
        {
            var andPolicy = new AndComposite();
            var basketPolicy = new MaxProductsInBasketPolicy(1);
            var productPolicy = new MaxAmountPolicy(product1.Barcode,1);
            andPolicy.Add(productPolicy);
            andPolicy.Add(basketPolicy);
            
            UpdatePurchasePolicy(StoreName, andPolicy);

            AddProductToCart(UserName, StoreName, product1.Barcode,2, product1.price);
            
            Assert.False(ValidateBasketPolicies(UserName,StoreName));

        }

        [Test]
        public void Or()
        {
            var orPolicy = new OrComposite();
            var basketPolicy = new MaxProductsInBasketPolicy(1);
            var productPolicy = new MaxAmountPolicy(product1.Barcode,1);
            orPolicy.Add(productPolicy);
            orPolicy.Add(basketPolicy);
            
            UpdatePurchasePolicy(StoreName, orPolicy);

            AddProductToCart(UserName, StoreName, product1.Barcode,2, product1.price);
            
            Assert.True(ValidateBasketPolicies(UserName,StoreName));
        }

        [Test]
        public void Conditioning()
        {
            var condition = new MaxProductsInBasketPolicy(1);
            var restricted = new MaxAmountPolicy(product1.Barcode,1);
            var conditioningPolicy = new ConditioningPolicy();
            
            conditioningPolicy.AddCondition(condition);
            conditioningPolicy.AddRestrictedPolicy(restricted);
            
            UpdatePurchasePolicy(StoreName, conditioningPolicy);

            AddProductToCart(UserName, StoreName, product1.Barcode,2, product1.price);
            
            Assert.True(ValidateBasketPolicies(UserName,StoreName));
        }

        [TearDown]

        public void Teardown()
        {
            var real = new RealProject();

            real.ResetStorePolicies(StoreName);
        }
        
        [OneTimeTearDown]

        public void OneTimeTearDown()
        {
            var real = new RealProject();
            real.DeleteUser(UserName);
        }

    }
}