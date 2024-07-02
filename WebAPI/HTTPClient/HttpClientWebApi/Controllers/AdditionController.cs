using System;
using HTTPClient;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web.Http;

namespace HttpClientWebApi.Controllers
{
    public class AdditionController : ApiController
    {
        CalculationEntities OE = new CalculationEntities();
        /// <summary>
        ///../api/Addition/
        /// </summary>
        /// <returns></returns>
        public IQueryable<Addition> Get()
        {
            return OE.Additions;
        }
        //../api/Addition/[int]
        public Addition Get(int id)
        {
            Addition addition = OE.Additions.Find(id);
            return addition;
        }

        //../api/Addition/
        public void Put(int id, Addition add)
        {
            OE.Entry(add).State = System.Data.Entity.EntityState.Modified;
            OE.SaveChanges();
        }

        public void Delete(int id)
        {
            Addition addition = OE.Additions.Find(id);
            OE.Additions.Remove(addition);
            OE.SaveChanges();
        }

        public void Post(Addition add)
        {
            OE.Additions.Add(add);
            OE.SaveChanges();
        }
    }
}
