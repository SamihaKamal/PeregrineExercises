using System;

namespace Sorting
{
    class Mergesort
    {
        private int[] array;

        public Mergesort(int[] a)
        {
            array = a;
            Sort(0, a.Length - 1);
        }

        public void Display()
        {
            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        private void Sort(int l, int r)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;
                Sort(l, m);
                Sort(m + 1, r);
                Merge(l, m, r);
            }
        }

        private void Merge(int l, int m, int r)
        {
            int[] temp = new int[array.Length];
            int i = l, j = m + 1, k = l;

            while (i <= m && j <= r)
            {
                if (array[i] <= array[j])
                {
                    temp[k++] = array[i++];
                }
                else
                {
                    temp[k++] = array[j++];
                }
            }

            while (i <= m)
            {
                temp[k++] = array[i++];
            }

            while (j <= r)
            {
                temp[k++] = array[j++];
            }

            for (i = l; i <= r; i++)
            {
                array[i] = temp[i];
            }
        }
    }
}
