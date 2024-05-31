using Newtonsoft.Json;

namespace JSON
{
    internal class Program
    {
        public class Account
        {
            public string? Email { get; set; }
            public bool Active { get; set; }
            public DateTime CreatedDate { get; set; }
            public IList<string> Roles { get; set; }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            Account account = new Account
            {
                Email = "jam@gmial.com",
                Active = true,
                CreatedDate = new DateTime(2013, 1, 20, 0, 0, 0, DateTimeKind.Utc),
                Roles = new List<string>
                {
                    "User",
                    "Developer",
                    "Admin"
                }
            };

            string json = JsonConvert.SerializeObject(account, Newtonsoft.Json.Formatting.Indented);
            Console.WriteLine(json);
            Console.WriteLine("---------------------");

            account = JsonConvert.DeserializeObject<Account>(json);
            Console.WriteLine(account.Email);
            Console.WriteLine("---------------------");
            string json2 = JsonConvert.SerializeObject(account.Roles, Newtonsoft.Json.Formatting.Indented);
            Console.WriteLine(json2);
            Console.ReadLine();

        }
    }
}
