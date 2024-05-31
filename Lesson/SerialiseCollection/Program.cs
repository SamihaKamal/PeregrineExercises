using Newtonsoft.Json;
namespace SerialiseACollection
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> videogames = new List<string>
            {
                "Starcraft"
                ,
                "Halo"
                ,
                "Legend of Zelda"
            };
            //Serialise a Collection
            string json = JsonConvert.SerializeObject(videogames);
            Console.WriteLine(json);
            Console.WriteLine(" ---------------------------");
            //Deserialise a Collection
            videogames = JsonConvert.DeserializeObject<List<string>>(json);
            Console.WriteLine(string.Join(", ", videogames.ToArray()));
            Console.WriteLine("----------------------------");
            //Another way of printing list.
            foreach (var game in videogames.ToArray())
            {
                Console.WriteLine(game);
            }
            Console.ReadLine();
        }
    }
}