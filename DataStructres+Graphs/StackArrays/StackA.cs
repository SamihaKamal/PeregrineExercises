using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackArrays
{
    class StackA
    {
        private int[] stackArray;
        private int top;

        public StackA()
        {
            stackArray = new int[10];
            top = -1;
        }

        public StackA(int maxSize)
        {
            stackArray = new int[maxSize];
            top = -1;
        }

        public int Size()
        {
            return top + 1;
        }

        public bool isEmpty()
        {
            return (top == -1);
        }

        public bool isFull()
        {
            return (top == stackArray.Length - 1);
        }

        public void Push(int x)
        {
            if (isFull())
            {
                Console.WriteLine("Stack overflow");
                return;
            }
            top = top + 1;
            stackArray[top] = x;
        }

        public int Pop()
        {
            int x;
            if (isEmpty())
            {
                throw new System.InvalidOperationException("Stack underflow");
            }
            x = stackArray[top];
            top = top - 1;
            return x;
        }

        public int Peek()
        {
            if (isEmpty())
            {
                throw new System.InvalidOperationException("Stack underflow");
            }
            return stackArray[top];
        }

        public void Display()
        {
            if (isEmpty())
            {
                Console.WriteLine("Stack is empty");
                return;
            }

            Console.WriteLine("Stack has: ");
            for (int i = top; i >=0; i--)
            {
                Console.WriteLine(stackArray[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
