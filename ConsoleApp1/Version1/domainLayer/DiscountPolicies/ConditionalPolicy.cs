namespace Version1.domainLayer.DiscountPolicies
{
    public class ConditionalPolicy : DiscountPolicy
    {
        Condition condition;
        int percentage;
        public ConditionalPolicy(string cond,int percentage)
        {
            this.percentage = percentage;
            condition = Condition.Parse(cond);
            
        }
  
        public override decimal getTotal(DTO_ShopingCart cart, DTO_Registered_User user, DTO_ItemInShop iis,int amount_of_item)
        {
            decimal res = 0;
            if (condition.evaluate(cart, user, iis, amount_of_item))
            {
                
                res = ((iis.base_price * (100 - percentage)) / 100) * amount_of_item;
            }
            else
            {
                
                res = iis.base_price * amount_of_item;
            }
            return res;
        }
    }
}