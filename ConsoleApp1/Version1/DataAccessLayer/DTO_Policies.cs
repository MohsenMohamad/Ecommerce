using System;
using Version1.domainLayer.DataStructures;
using Version1.domainLayer.DiscountPolicies;

namespace Version1.DataAccessLayer
{
    public class DTO_Policies
    {
        //1 is public policy 2 is conditional policy
        public int Type;   // DiscountPolicy is an enum  ///// Public Policy Fields

        public int percentage; //// between 0 and 100
        /////////////

        /////////////Conditional Policy Fields case
        public string conditoin;
        public int conditoin_percentage;
        ////////////
        public int discount_policy_id;
        public string discount_description;

        public DTO_Policies()
        {
            discount_description = "";
        }
        private void clearPublic()
        {
            percentage = -1;
        }
        public int SetPublic( int percentage)
        {
            if (percentage < 0 || percentage > 100)
                return -14;

            clearConditional();
            this.percentage = percentage;
            this.Type = 1;
            
            return 1;
        }

        private void clearConditional() { }

        public int SetConditional(int percentage, string condition)
        {
            if (percentage > 100 || percentage < 0)
                return -14;
            clearPublic();
            //set conditional type
            this.Type = 2;

            conditoin_percentage = percentage;
            this.conditoin = condition;
            return 1;
        }

        
    }
}