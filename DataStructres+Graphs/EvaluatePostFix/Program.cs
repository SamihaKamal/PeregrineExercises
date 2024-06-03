using System;
using System.Dynamic;
using System.Collections;
using EvaluatePostFix;

namespace EvaluatePostFix
{
    internal class Program
    {
        public static bool HasHigherPrec(char op1, char op2)
        {
            if (op2 == '-')
            {
                return false;
            }
            else if (op2 == '*')
            {
                return true;
            }
            else if (op2 == '/' && (op1 == '+' || op1 == '-'))
            {
                return true;
            }
            else if (op2 == '+' && (op1 == '-'))
            {
                return true;
            }
            return false;
        }

        public static bool isDigit(char c)
        {
            if ('0' <= c && '9' >= c)
                return true;
            return false;
        }

        static void Main(string[] args)
        {
            EvalPostFix ex = new EvalPostFix();
            Stack s = new Stack();
            string yes = "";
            string exp;

            Console.WriteLine("Insert expression (Do not leave spaces between characters)");
            exp = Console.ReadLine();
            char[] arr = exp.ToCharArray();
            for (int i =0; i <exp.Length; i++)
            {
                if (isDigit(arr[i]))
                {
                    yes = yes + arr[i] + " ";
                }
                else if (!isDigit(arr[i]))
                {
                    while (s.Count != 0 && HasHigherPrec((char)s.Peek(), arr[i]))
                    {
                        yes = yes + s.Peek() + " ";
                        s.Pop();
                    }
                    s.Push(arr[i]);
                    
                    
                }
            }
            while (s.Count != 0)
            {
                yes = yes + s.Peek() + " ";
                s.Pop();
            }
          

            int Answer = ex.evaluate(yes);
            Console.WriteLine($"The answer is {Answer}");
            Console.ReadLine();
        }

       
    }
}
