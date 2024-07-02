using HTTPClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HttpClientWebApi.Controllers
{
    public class DivisionController : ApiController
    {
        CalculationEntities OE = new CalculationEntities();
        /// <summary>
        ///../api/Addition/
        /// </summary>
        /// <returns></returns>
        public IQueryable<Division> Get()
        {
            return OE.Divisions;
        }
        //../api/Addition/[int]
        public Division Get(int id)
        {
            Division sub = OE.Divisions.Find(id);
            return sub;
        }

        //../api/Addition/
        public void Put(int id, Division add)
        {
            OE.Entry(add).State = System.Data.Entity.EntityState.Modified;
            OE.SaveChanges();
        }

        public void Delete(int id)
        {
            Division sub = OE.Divisions.Find(id);
            OE.Divisions.Remove(sub);
            OE.SaveChanges();
        }

        public void Post(Division add)
        {
            OE.Divisions.Add(add);
            OE.SaveChanges();
        }
    }
}
