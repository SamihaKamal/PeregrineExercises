using HTTPClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HttpClientWebApi.Controllers
{
    public class SubtractionController : ApiController
    {
        CalculationEntities OE = new CalculationEntities();
        /// <summary>
        ///../api/Addition/
        /// </summary>
        /// <returns></returns>
        public IQueryable<Subtraction> Get()
        {
            return OE.Subtractions;
        }
        //../api/Addition/[int]
        public Subtraction Get(int id)
        {
            Subtraction sub = OE.Subtractions.Find(id);
            return sub;
        }

        //../api/Addition/
        public void Put(int id, Subtraction add)
        {
            OE.Entry(add).State = System.Data.Entity.EntityState.Modified;
            OE.SaveChanges();
        }

        public void Delete(int id)
        {
            Subtraction sub = OE.Subtractions.Find(id);
            OE.Subtractions.Remove(sub);
            OE.SaveChanges();
        }

        public void Post(Subtraction add)
        {
            OE.Subtractions.Add(add);
            OE.SaveChanges();
        }
    }
}
