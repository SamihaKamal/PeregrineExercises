namespace Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            int[] numbers = new[] { 1, 2, 3, 4, 5 };
            Console.WriteLine(numbers.Count());
            numbers = numbers.Append<int>(10).ToArray();
            numbers = numbers.Prepend<int>(0).ToArray();
            for (int x = 0; x < numbers.Length; x++)
            {
                Console.Write($" {numbers[x]} , ");
            }
            Console.WriteLine("Workign with string array");
            string[] dayArray = new string[] { "Mon", "Tue" };
            dayArray = dayArray.Append("Wed").ToArray();

            foreach (var item in dayArray)
            {
                Console.Write(item + ", ");
            }

            Console.WriteLine("\nWorking with objects");
            object[] obj = new[] { "12", "2.5", "8", "monday", "tuesday" };
            foreach (var item in obj)
            {
                Console.Write(item + " , ");
            }

            Console.WriteLine("\nInteger reversal");
            int[] a = { 1, 2, 3, 4, 5, 6 };

            for (int i = a.Length - 1; i >= 0; i--)
            {
                Console.Write(a[i] + " ");
            }
            Console.ReadLine();
        }
    }
}
