namespace GCD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 42;
            int b = 112;

            Console.WriteLine(GCD(a, b));
        }

        public static int GCD(int m, int n)
        {
            if(n == 0)
            {
                return m;
            }
            return (GCD(n, m % n));
        }
    }
}
