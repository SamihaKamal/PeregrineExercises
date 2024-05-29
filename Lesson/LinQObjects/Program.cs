namespace LinQObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string likes = "I like fruit";
            string[] fruits = { "Orange", "Apple", "Grapefruit", "Pear", "Pineapple", "Grapes", "Peach", "Melon", "Coconut" };
            int[] numbers = { 2, 4, 5, 4, 6, 22, 3, 22, 1, 23, 66, 33, 42, 12, 412, 645, 32, 67, 34, 56 };
            var getNumbers = from number in numbers where number < 10 select number;
            var getFruit = from fruit in fruits where fruit.Contains("G") && (fruit.Length<8) select fruit;
            var getEven = from number in numbers where number % 2 == 0 orderby number select number;
            Console.WriteLine(string.Join(",", getNumbers));
            Console.WriteLine(String.Join(",", getFruit));
            Console.WriteLine(string.Join(",", getEven));
            Console.ReadLine();
        }
    }
}
