﻿using System;
using ServiceLogic.DataAccessLayer.DataStructures;

namespace ServiceLogic.DomainLayer.StoreFeatures.DiscountPolicies
{
    public class Xor : Condition
    {
        private Condition leftOperand;
        private Condition rightOperand;


        public override bool evaluate(ShoppingCart cart, User user, Product item, int amount_of_item)
        {
            return leftOperand.evaluate(cart, user, item, amount_of_item) ^ rightOperand.evaluate(cart, user, item, amount_of_item);
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
            if (leftOperand == null || rightOperand == null)
                throw new Exception("");
            return $"({leftOperand.ToString()}    ^   {rightOperand.ToString()})";
        }
        public override string get_description()
        {
            return $"({leftOperand.get_description()}    ^   {rightOperand.get_description()})";
        }
    }
}