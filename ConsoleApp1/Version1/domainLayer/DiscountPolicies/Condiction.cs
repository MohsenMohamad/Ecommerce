using System;
using System.Collections.Generic;
using System.Linq;
using Version1.domainLayer.DataStructures;

namespace Version1.domainLayer.DiscountPolicies
{
    public abstract class Condition
    {
        public abstract bool evaluate(ShoppingCart cart, User user, Product product, int amount_of_item);
        public abstract string get_description();
        public static Condition Parse(string s)
        {
            string[] s1 = MySplit_spaceClear(s, new char[] { ',', ' ', ')', '(' });
            if (MySplit(s, new char[] { ',' }).Length == 1)
            {
                return getBaseCondition(s);
            }
            else
            {

                switch (s1[1])
                {
                    case "xor":
                        Xor xor = new Xor();
                        Condition left = Parse(getleftOperand(s1));
                        Condition right = Parse(getrightOperand(s1));
                        xor.SetOperands(left, right);
                        return xor;
                    case "and":
                        And and = new And();
                        Condition left1 = Parse(getleftOperand(s1));
                        Condition right1 = Parse(getrightOperand(s1));
                        and.SetOperands(left1, right1);
                        return and;
                    case "or":
                        Or or = new Or();
                        Condition left2 = Parse(getleftOperand(s1));
                        Condition right2 = Parse(getrightOperand(s1));
                        or.SetOperands(left2, right2);
                        return or;

                    default:
                        throw new Exception("bad Format");
                }

            }

        }

        private static string getrightOperand(string[] s1)
        {
            string res;
            int start = -1, end = s1.Length - 1, counter = 0;
            for (int i = 3; i < s1.Length; i++)
            {
                if (s1[i] == "(")
                    counter++;
                else if (s1[i] == ")")
                    counter--;
                else if (s1[i] == "," && counter == 0)
                {
                    start = i + 1;
                    break;
                }
            }
            if (start == -1)
                throw new Exception("bad Format");
            string[] _res = new string[end - start];
            Array.Copy(s1, start, _res, 0, end - start);
            res = String.Join("", _res);
            return res;
        }

        private static string getleftOperand(string[] s1)
        {

            string res;
            int start = 3, end = -1, counter = 0;
            for (int i = 3; i < s1.Length; i++)
            {
                if (s1[i] == "(")
                    counter++;
                else if (s1[i] == ")")
                    counter--;
                else if (s1[i] == "," && counter == 0)
                {
                    end = i;
                    break;
                }
            }
            if (end == -1)
                throw new Exception("bad Format");
            string[] _res = new string[end - start];
            Array.Copy(s1, start, _res, 0, end - start);
            res = String.Join("", _res);
            return res;
        }

        private static Condition getBaseCondition(string s)
        {
            s = s.Trim();


            char[] s2 = s.ToCharArray().ToList().Where(element => element != ' ').ToArray();
            if (s.ToCharArray()[1] == 'T')
            {
                return new True();
            }
            else if (s.ToCharArray()[1] == 'F')
            {
                return new False();
            }
            else if (s.ToCharArray()[1] == 'A')
            {
                return new Buy_a_of_X(s.Substring(3, s.Length - 3 - 2));
            }
            else if (s.ToCharArray()[1] == 'B')
            {
                return new Spend_More_Than_Y(s.Substring(3, s.Length - 3 - 2));
            }
            else if (s.ToCharArray()[1] == 'C')
            {
                return new Item_Category(s.Substring(3, s.Length - 3 - 2));
            }
            else
            {
                throw new Exception("bad Format");
            }
        }
        private static IEnumerable<string> SplitAndKeep(string s, char[] delims)
        {
            int start = 0, index;

            while ((index = s.IndexOfAny(delims, start)) != -1)
            {
                if (index - start > 0)
                    yield return s.Substring(start, index - start);
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
        private static string[] MySplit_spaceClear(string s, char[] del)
        {
            return SplitAndKeep(s, del).ToList().Where(element => element != " ").ToArray();
        }
        public static void print(string[] yourArray)
        {
            foreach (var item in yourArray)
            {
                Console.WriteLine(item.ToString());
            }
        }

    }

}