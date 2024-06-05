namespace Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 10;

            Console.WriteLine(fibonacci(a));

        }

        public static int fibonacci(int n)
        {
            if(n <= 1)
            {
                return n;
            }
            return fibonacci(n-1) + fibonacci(n-2);
        }
    }
}
