using HTTPClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HttpClientWebApi.Controllers
{
    public class MultiplyController : ApiController
    {
        CalculationEntities OE = new CalculationEntities();
        /// <summary>
        ///../api/Addition/
        /// </summary>
        /// <returns></returns>
        public IQueryable<Multiplication> Get()
        {
            return OE.Multiplications;
        }
        //../api/Addition/[int]
        public Multiplication Get(int id)
        {
            Multiplication sub = OE.Multiplications.Find(id);
            return sub;
        }

        //../api/Addition/
        public void Put(int id, Multiplication add)
        {
            OE.Entry(add).State = System.Data.Entity.EntityState.Modified;
            OE.SaveChanges();
        }

        public void Delete(int id)
        {
            Multiplication sub = OE.Multiplications.Find(id);
            OE.Multiplications.Remove(sub);
            OE.SaveChanges();
        }

        public void Post(Multiplication add)
        {
            OE.Multiplications.Add(add);
            OE.SaveChanges();
        }
    }
}
