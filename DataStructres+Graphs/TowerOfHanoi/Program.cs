namespace TowerOfHanoi
{
    internal class Program
    {
      
        static void Main(string[] args)
        {
            int num = 4;
            Console.WriteLine("Tje sequence of moves ivolved in the tower of hanoi are: ");
            TowerOfHanoi(num, 'A', 'C', 'B');
            Console.ReadLine();
        }

        public static void TowerOfHanoi(int a, char src, char dst, char temp)
        {
            if (a == 1)
            {
                Console.WriteLine($"{a} is moved from {src} to {dst}");
            }
            else
            {
                TowerOfHanoi(a - 1, src, temp, dst);
                Console.WriteLine($"Disk {a} is being moved from {src} to {dst}");
                TowerOfHanoi(a - 1, temp, dst, src);
            }
        }
    }
}
