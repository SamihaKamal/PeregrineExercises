using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
namespace corewepapd.Pages
{
    public class Customer
    {
        public String Id { get; set; }
        public string Name { get; set; }
    }
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public readonly IConfiguration _configuration;
        
        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
           
        }
        public List<Customer> customers { get; set; }
        public void OnGet()
        {
            string cnstr = _configuration.GetSection("ConnectionStrings")["MyDb"];
            SqlConnection con = new SqlConnection(cnstr);
            string sqlString = "Select * from Customers;";
            
            SqlCommand cmd = new SqlCommand(sqlString, con);
            cmd.Connection = con;
            con.Open();
            //Executereader for select, executenonquery for insert update and delete, execute scalar for count or single numbers
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read() == true)
            {
                Customer customer = new Customer
                {
                    Id = dr["CustomerID"].ToString(),
                    Name = dr["ContactName"].ToString(),
                };
                customers.Add(customer);
            }

            dr.Close();
            con.Close();
        }
    }
}
