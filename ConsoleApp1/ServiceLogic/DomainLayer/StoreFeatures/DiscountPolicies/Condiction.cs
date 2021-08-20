using System;
using System.Collections.Generic;
using System.Linq;
using ServiceLogic.DataAccessLayer.DataStructures;

namespace ServiceLogic.DomainLayer.StoreFeatures.DiscountPolicies
{
    public abstract class Condition
    {
        public abstract bool evaluate(ShoppingCart cart, User user, Product product, int amount_of_item);
        public abstract string get_description();
        public static Condition Parse(string s)
        {
            string[] s1 = ClearSpace(s, new char[] { ',', ' ', ')', '(' });
            if (MySplit(s, new char[] { ',' }).Length == 1)
            {
                return GetBaseCondition(s);
            }
            else
            {
                if (s1[1] == "xor")
                    return getXor(s1);
                else if (s1[1] == "and")
                    return getAnd(s1);
                else if (s1[1] == "or")
                    return getOr(s1);
                else
                    throw new Exception("wrong format");
            }

        }

        private static Condition getOr(string[] s1)
        {
            Or or = new Or();
            Condition left2 = Parse(getleftOperand(s1));
            Condition right2 = Parse(getrightOperand(s1));
            or.SetOperands(left2, right2);
            return or;
        }

        private static Condition getAnd(string[] s1)
        {
            And and = new And();
            Condition left1 = Parse(getleftOperand(s1));
            Condition right1 = Parse(getrightOperand(s1));
            and.SetOperands(left1, right1);
            return and;
        }

        private static Condition getXor(string[] s1)
        {
            Xor xor = new Xor();
            Condition left = Parse(getleftOperand(s1));
            Condition right = Parse(getrightOperand(s1));
            xor.SetOperands(left, right);
            return xor;
        }

        private static string getrightOperand(string[] s1)
        {
            var start = -1;
            var end = s1.Length - 1;
            var counter = 0;

            start = getStartIndex(s1, counter, start);
            if (start == -1)
                throw new Exception("wrong Format");
            
            var _res = new string[end - start];
            
            Array.Copy(s1, start, _res, 0, end - start);
            
            return string.Join("", _res);
        }

        private static int getStartIndex(string[] s1, int counter, int start)
        {
            for (int i = 3; i < s1.Length; i++)
            {
                if (s1[i] == "(") counter++;
                else if (s1[i] == ")") counter--;
                else if (s1[i] == "," && counter == 0)
                {
                    start = i + 1;
                    break;
                }
            }

            return start;
        }

        private static string getleftOperand(string[] s1)
        {

            
            int start = 3, end = -1, counter = 0;
            for (int i = 3; i < s1.Length; i++)
            {
                if (s1[i] == "(") counter++;
                else if (s1[i] == ")") counter--;
                else if (s1[i] == "," && counter == 0)
                {
                    end = i;
                    break;
                }
            }
            if (end == -1)
                throw new Exception("wrong Format");
            
            string[] _res = new string[end - start];
            
            Array.Copy(s1, start, _res, 0, end - start);
            
            return String.Join("", _res);
        }

        private static Condition GetBaseCondition(string s)
        {
            s = s.Trim();
            var s2 = s.ToCharArray().ToList().Where(element => element != ' ').ToArray();
            if (s.ToCharArray()[1] == 'A')
                return new BuyAOfX(s.Substring(3, s.Length - 3 - 2));
            if (s.ToCharArray()[1] == 'B')
                return new Spend_More_Than_Y(s.Substring(3, s.Length - 3 - 2));
            if (s.ToCharArray()[1] == 'C')
                return new Item_Category(s.Substring(3, s.Length - 3 - 2));
            if (s.ToCharArray()[1] == 'T')
                return new True();
            if (s.ToCharArray()[1] == 'F')
                return new False();
            //no other case
            throw new Exception("wrong Format");
        }
        private static IEnumerable<string> SplitAndKeep(string s, char[] delims)
        {
            int start = 0, index;
            while ((index = s.IndexOfAny(delims, start)) != -1)
            {
                if (index - start > 0) yield return s.Substring(start, index - start);
                yield return s.Substring(index, 1);
                start = index + 1;
            }

            if (start < s.Length)
            {
                yield return s.Substring(start);
            }
        }
        private static string[] MySplit(string s, char[] del)
        {
            return SplitAndKeep(s, del).ToArray();
        }
        private static string[] ClearSpace(string s, char[] del)
        {
            return SplitAndKeep(s, del).ToList().Where(element => element != " ").ToArray();
        }

    }

}