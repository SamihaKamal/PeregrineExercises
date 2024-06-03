using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluatePostFix
{
    public class EvalPostFix
    {
        public int operation(char op, int op1, int op2)
        {
            switch (op)
            {
                case '/':
                    return op1 / op2;
                case '*':
                    return op1 * op2;
                case '+':
                    return op1 + op2;
                case '-':
                    return op1 - op2;
            }
            return 0;
        }

        public bool isDigit(char c)
        {
            if ('0' <= c && '9' >= c)
                return true;
            return false;
        }
        public int evaluate(string exp)
        {
            Stack st = new Stack();
            char[] arr = exp.ToCharArray();
            int op1, op2;
            for (int i = 0; i < exp.Count(); i++)
            {
                if (arr[i] == ' ' || arr[i] == ',')
                    continue;
                else if (arr[i] == '*' || arr[i] == '/' || arr[i] == '+' || arr[i] == '-')
                {
                    op2 = Convert.ToInt32(st.Pop());
                    op1 = Convert.ToInt32(st.Pop());
                    st.Push(operation(arr[i], op1, op2));
                }
                else if (isDigit(arr[i]))
                {
                    int operand = 0;
                    while
                    (i < exp.Count() && isDigit(arr[i]))
                    {
                        operand = (operand * 10) + (arr[i] - '0');
                        i++;
                    }
                    i--;
                    st.Push(operand);
                }
            }
            return Convert.ToInt32(st.Pop());

        }
    }
}
