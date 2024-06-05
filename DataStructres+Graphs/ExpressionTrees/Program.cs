using System.Text.RegularExpressions;

namespace ExpressionTrees
{
    internal class Program
    {
        public class Implementation
        {
            public int precedence(char op)
            {
                if (op == '*' || op == '/' || op == '%')
                {
                    return 2;
                }
                else if (op == '+' || op == '-')
                {
                    return 1;
                }
                else if (op == '^')
                {
                    return 3;
                }
                else
                {
                    return -1;
                }
            }
            public string infix_to_postfix(ref string expn)
            {
                Stack<char> stk = new Stack<char>();
                string output = "";
                char _out;
                foreach (var ch in expn)
                {
                    bool isAlphaBet = Regex.IsMatch(ch.ToString(), "[a-z]", RegexOptions.IgnoreCase);
                    if (char.IsDigit(ch) || isAlphaBet)
                    {
                        output = output + ch;
                    }
                    else
                    {
                        switch (ch)
                        {
                            case '+':
                            case '-':
                            case '*':
                            case '/':
                            case '%':
                            case '^':
                                while (stk.Count > 0 && precedence(ch) <= precedence(stk.Peek()))
                                {
                                    _out = stk.Peek();
                                    stk.Pop();
                                    output = output + "" + _out;
                                }
                                stk.Push(ch);
                                output = output + "";
                                break;
                            case '(':
                                stk.Push(ch);
                                break;
                            case ')':
                                while (stk.Count > 0 && (_out = stk.Peek()) != '(')
                                {
                                    stk.Pop();
                                    output = output + "" + _out + "";
                                }
                                if (stk.Count > 0 && (_out = stk.Peek()) == '(')
                                {
                                    stk.Pop();
                                }
                                break;
                        }
                    }
                }
                while (stk.Count > 0)
                {
                    _out = stk.Peek();
                    stk.Pop();
                    output = output + _out;
                }
                return output;
            }
        }
        static void Main(string[] args)
        {
            ExpressionTree etree = new ExpressionTree();
            string input;
            Console.WriteLine("--------------");
            Implementation imp = new Implementation();
            input = "1+2^3+2+3";
            string postfix = imp.infix_to_postfix(ref input);
            Console.WriteLine("infix: " + input);
            Console.WriteLine("postfix: " + postfix);
            Console.WriteLine("---------------");

            etree.BuildTree(postfix);
            etree.BuildTree(postfix);
            etree.Display();

            Console.Write("Prefix: ");
            etree.Prefix();
            Console.Write("Postfix: ");
            etree.Postfix();
            Console.Write("Infix: ");
            etree.ParenthesizedInfix();

            Console.WriteLine("Value: " + etree.Evaluate());
            Console.ReadLine();
        }
    }
}
