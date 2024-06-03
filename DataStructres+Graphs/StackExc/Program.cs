using System;
using System.Collections;
namespace StackExc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();
            Stack compare = new Stack();
            compare.Push("(");
            compare.Push("{");
            compare.Push("[");
            compare.Push("]");
            compare.Push("}");
            compare.Push(")");
            string[] exp = new string[] { "{", "]", "[", ")", "}", "(" };
            int n = exp.Count();

            while (stack.Contains("(") != compare.Contains("("))
            {
                for (int i = 0; i < exp.Length; i++)
                {
                    pushOrder(stack, exp[i]);             
                }
            }
            Console.WriteLine("Original array was: ");
            foreach (var a in exp)
            {
                Console.Write(a);
            }
            Console.WriteLine();
            Console.WriteLine("Ordered array is:");
            foreach (var item in stack)
            {
                Console.Write(item);
            }
            
            Console.ReadLine();
            
            

        }

        public static void pushOrder(Stack a, string b)
        {
            //If empty, then skip unless its a (
            //Otherwise check whats currently in, if its ( then pop in a { otherwise skip
            //likewise if the top has { then pop in [ otherwise skip.
            if (a.Count == 0 && b == ")")
            {
                a.Push(b);
            }
            else if (a.Count != 0 && isHigherPri(a.Peek().ToString(), b))
            {
                a.Push(b);
            }

            if (a.Count != 0)
            {
                if (a.Peek().ToString() == "]" && b == "[")
                {
                    a.Push(b);
                }
                else if (isHigherPri(a.Peek().ToString(), b))
                {
                    a.Push(b);
                }
            }
           
        }

        public static bool isHigherPri(string a, string b)
        {
            if (isOpeningBracket(b))
            {
                switch (a)
                {
                    case "[":
                        if(b == "{")
                        {
                            return true;
                        }
                        break;
                    case "{":
                        if (b == "(")
                        {
                            return true;
                        }
                        break;
                    default:
                        return false;
                }
            }
            if (isClosingBracket(b))
            {
                switch (a)
                {
                    case ")":
                        if (b == "}")
                        {
                            return true;
                        }
                        break;
                    case "}":
                        if (b == "]")
                        {
                            return true;
                        }
                        break;
                    default:
                        return false;
                        
                }
            }
            return false;
        }

        public static bool isOpeningBracket(string a)
        {
           if (a == "(" || a == "{" || a == "[")
            {
                return true;
            }
            return false;
        }

        public static bool isClosingBracket(string a)
        {
            if (a == ")" || a == "}" || a == "]")
            {
                return true;
            }
            return false;
        }
    }
}
