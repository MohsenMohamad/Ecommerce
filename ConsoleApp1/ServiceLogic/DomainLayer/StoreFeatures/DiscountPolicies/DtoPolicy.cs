namespace ServiceLogic.DomainLayer.StoreFeatures.DiscountPolicies
{
    public class DtoPolicy
    {
        //1 is public policy 2 is conditional policy
        public int TypeOfPolicy;
        
        //Public Policy Field
        public int Percentage;
        
        //Conditional Policy Fields case
        public string Conditoin;
        public int ConditoinPercentage;
        public string DiscountDescription;

        public DtoPolicy()
        {
            DiscountDescription = "";
        }
        private void ClearPublic()
        {
            Percentage = -1;
        }
        public int SetPublic( int percentage)
        {
            if (percentage < 0 || percentage > 100)
                return -14;
            
            this.Percentage = percentage;
            this.TypeOfPolicy = 1;
            
            return 1;
        }
        
        public int SetConditional(int percentage, string condition)
        {
            if (percentage > 100 || percentage < 0)
                return -14;
            ClearPublic();
            ConditoinPercentage = percentage;
            this.TypeOfPolicy = 2;
            this.Conditoin = condition;
            
            return 1;
        }

        
    }
}