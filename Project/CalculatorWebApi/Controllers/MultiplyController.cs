using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CalculatorWebApi.Controllers
{
    public class MultiplyController : ApiController
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "multiply" };
        }

        // GET api/values/5&6
        public int Get(int num1, int num2)
        {
            int result = num1 * num2;

            return result;
        }

    }
}
