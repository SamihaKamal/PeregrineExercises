using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    internal class Quicksort
    {
        int[] array;

        public Quicksort(int[] a)
        {
            array = a;
            Quicking(a, 0, a.Length-1);
            array = a;
        }

        public void Display()
        {
            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
        public void Swap(int[] a, int i, int j)
        {
            int t = a[i];
            a[i] = a[j];
            a[j] = t;
        }

        private int Partition(int[] a, int l, int r)
        {
            int ndx = l;
            int pivot = a[l];
            for(int i=l+1; i<=r; i++)
            {
                if (a[i] < pivot)
                {
                    ndx++;
                    Swap(a, ndx, 1);
                }
            }
            Swap(a, ndx, l);
            return ndx;
        }

        private void Quicking(int[] a, int l, int r)
        {
            if (l < r)
            {
                var pi = Partition(a, l, r);
                Quicking(a, l, pi - 1);
                Quicking(a, pi + 1, r);
            }
        }
    }

   
}
