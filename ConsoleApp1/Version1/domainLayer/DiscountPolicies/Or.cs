using Version1.domainLayer.DataStructures;

namespace Version1.domainLayer.DiscountPolicies
{
    public class Or : Condition
    {
        private Condition leftOperand;
        private Condition rightOperand;

        public override bool evaluate(ShoppingCart cart, User user, Product item, int amount_of_item)
        {
            return leftOperand.evaluate(cart, user, item, amount_of_item) || rightOperand.evaluate(cart, user, item, amount_of_item);
        }

        public void SetLeftOperand(Condition left)
        {
            leftOperand = left;
        }
        public void SetRightOperand(Condition right)
        {
            rightOperand = right;
        }
        public void SetOperands(Condition left, Condition right)
        {
            SetLeftOperand(left);
            SetRightOperand(right);
        }
        public override string ToString()
        {
            return string.Format("({0}    ||   {1})", leftOperand.ToString(), rightOperand.ToString());
        }
        public override string get_description()
        {
            return string.Format("({0}    ||   {1})", leftOperand.get_description(), rightOperand.get_description());
        }
    }
}