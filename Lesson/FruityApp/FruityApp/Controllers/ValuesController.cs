using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FruityApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        List<string> fruitList = new List<string>
        {
            "Apple: 24",
            "Banana: 15",
            "Grapes: 10",
        };

        public ValuesController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<String> Get()
        {
            string filepath = @"C:\Users\44747\Documents\GitHub\PeregrineExercises\Lesson\FruitFile.txt";
            string text = System.IO.File.ReadAllText(filepath);
            foreach (string line in text.Split(","))
            {
                fruitList.Add(line);
            }
            _logger.LogError("Get performed succesfully :D ");
            return fruitList;
        }

        [HttpPost]
        public string? PostValue([FromBody] string? value)
        {
            if (value != null && value != "")
            {
                string filepath = @"C:\Users\44747\Documents\GitHub\PeregrineExercises\Lesson\FruitFile.txt";
                string text = System.IO.File.ReadAllText(filepath);
                string totaltext = (string)text + "," + value;
                System.IO.File.WriteAllText(filepath, totaltext);
                foreach (string line in totaltext.Split(","))
                {
                    fruitList.Add(line);
                }
            }

            if (value != null && value != "")
            {
                _logger.LogInformation($"Added sucessfully: value : {value}");
                return "sucess";
            }
            else
            {
                _logger.LogError("bad data");
                return "not added";
            }
        }
    }
}
