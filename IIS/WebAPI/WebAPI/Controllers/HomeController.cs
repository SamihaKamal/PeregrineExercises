using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class HomeController : ApiController
    {
        private string[] s = { "apple", "banana", "cheese" };
        public string[] Get()
        {
            return s;
        }

        public string Get(int id)
        {
            return s[id];
        }
    }
}
