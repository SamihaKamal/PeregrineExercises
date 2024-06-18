﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTrees
{
    internal class ExpressionTree
    {
        Node? root;

        public ExpressionTree()
        {
            root = null;
        }

        static bool isOperator(char c)
        {
            if (c == '+' || c == '-' || c == '*' || c == '/' || c == '^')
                return true;
            return false;
        }

        public void BuildTree(String postfix)
        {
            StackNode stack = new StackNode(30);
            Node t;

            for (int i=0; i<postfix.Length; i++)
            {
                if (isOperator(postfix[i]))
                {
                    t = new Node(postfix[i]);
                    t.rchild = stack.Pop();
                    t.lchild = stack.Pop();
                    stack.Push(t);
                }
                else
                {
                    t = new Node(postfix[i]);
                    stack.Push(t);
                }
            }
            root = stack.Pop();
        }

        public void Prefix()
        {
            Preorder(root);
            Console.WriteLine();
        }

        private void Preorder(Node p)
        {
            if (p == null)
            {
                return;
            }
            Console.Write(p.info);
            Preorder(p.lchild);
            Preorder(p.rchild);
        }

        public void Postfix()
        {
            Postorder(root);
            Console.WriteLine();
        }

        private void Postorder(Node p)
        {
            if (p == null)
            {
                return;
            }
            Postorder(p.lchild);
            Postorder(p.rchild);
            Console.Write(p.info);
        }

        public void ParenthesizedInfix()
        {
            Inorder(root);
            Console.WriteLine();
        }

        private void Inorder(Node p)
        {
            if (p == null)
                return;
            if (isOperator(p.info))
                Console.Write("(");
            Inorder(p.lchild);
            Console.Write(p.info);
            Inorder(p.rchild);

            if (isOperator(p.info))
                Console.Write(")");
        }

        public void Display()
        {
            Display(root, 0);
            Console.WriteLine();
        }

        private void Display(Node p, int level)
        {
            int i;
            if (p == null)
                return;
            Display(p.rchild, level + 1);
            Console.WriteLine();

            for (i=0; i<level; i++)
            {
                Console.Write("   ");
            }
            Console.Write(p.info);
            Display(p.lchild, level + 1);
        }

        public int Evaluate()
        {
            if (root == null)
                return 0;
            else
                return Evaluate(root);
        }

        private int Evaluate(Node p)
        {
            if (!isOperator(p.info))
            {
                return Convert.ToInt32(Char.GetNumericValue(p.info));
            }
            int leftValue = Evaluate(p.lchild);
            int rightValue = Evaluate(p.rchild);

            if(p.info == '+')
            {
                return leftValue + rightValue;
            }else if(p.info == '-')
            {
                return leftValue - rightValue;
            }else if (p.info == '*')
            {
                return leftValue * rightValue;
            }else if (p.info == '^')
            {
                double left = (double)leftValue;
                double right = (double)rightValue;
                
                return Convert.ToInt32(Math.Pow(left, right));
            }
            else
            {
                return leftValue / rightValue;
            }
        }
    }
}