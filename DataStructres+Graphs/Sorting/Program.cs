namespace Sorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 9, 1, 8, 2, 7, 3, 6, 4, 5 };
            Mergesort b = new Mergesort(array);
            /*Mergesort is O(nLogn) because it splits the sequence into two multiple times (dividsion into half is log n time
             complexity) but the merge step works back into each number of the array so its On and therfore u times the two 
             together to get a big o of O(nLogn)*/
            b.Display();
            Quicksort a = new Quicksort(array);
            a.Display();
            /*Same as mergesort, the big o notation is 0(nlogn) because it splits the array into two partitions and does its partioning
             with n complexity*/
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
