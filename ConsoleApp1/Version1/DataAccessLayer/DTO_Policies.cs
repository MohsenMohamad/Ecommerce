using System;
using Version1.domainLayer.DataStructures;
using Version1.domainLayer.DiscountPolicies;

namespace Version1.DataAccessLayer
{
    public class DTO_Policies
    {
        //1 is public policy 2 is conditional policy
        public int Type;   // DiscountPolicy is an enum  ///// Public Policy Fields
        public bool bound;
        public string fromdate;
        public string todate;
        public int percentage; //// between 0 and 100
        /////////////

        /////////////Conditional Policy Fields case
        public string conditoin;
        public int conditoin_percentage;
        ////////////
        public int discount_policy_id;
        public string discount_description;
        public bool Bound()
        {
            return bound;
        }

        public DTO_Policies()
        {
            discount_description = "";
        }
        private void clearPublic()
        {
            fromdate = "";
            todate = "";
            percentage = -1;
            bound = false;
        }
        public int SetPublic(string from, string to, int percentage, bool bound)
        {
            if (percentage < 0 || percentage > 100)
                return -14;
            clearHidden();
            clearConditional();
            this.percentage = percentage;
            this.Type = 1;
            if (bound)
                this.bound = true;
            else
                this.bound = false;
            DateTime dt = new DateTime();
            if (DateTime.TryParse(from, out dt) && DateTime.TryParse(to, out dt) && percentage <= 100 && percentage >= 0)
            {
                fromdate = from;
                todate = to;
            }
            else
            {
                if (bound)
                    return -15;
            }
            return 1;
        }
        private void clearHidden()
        {
            bound = false;
        }
        private void clearConditional() { }

        public int SetConditional(int percentage, string condition)
        {
            if (percentage > 100 || percentage < 0)
                return -14;
            clearPublic();
            clearHidden();
            //set conditional type
            this.Type = 2;

            conditoin_percentage = percentage;
            this.conditoin = condition;
            return 1;
        }

        
    }
}