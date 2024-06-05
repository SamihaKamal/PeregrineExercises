using System.Diagnostics;
namespace BigO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Stopwatch t = new Stopwatch();
            t.Start();
            long m = fun1(2000000000);
            t.Stop();
            TimeSpan ts = t.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine($"elapsed time = {elapsedTime}");
            Console.ReadLine();
        }

        public static int fun1(long n)
        {
            int m = 0;
            for (long i = 0; i < n; i++)
            {
                m += 1;
            }
            return m;
        }
    }
}
