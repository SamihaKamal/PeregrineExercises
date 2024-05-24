namespace ObjectOrientedProgramming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Arithmetic a = new Arithmetic();
            Console.WriteLine(a.Add(3, 4));
            Console.WriteLine(a.mult(3, 4));
            Console.WriteLine(a.Sub(3, 4));
            Console.ReadLine();
        }
    }
}
