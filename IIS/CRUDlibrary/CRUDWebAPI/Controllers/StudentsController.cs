using CRUDlibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUDWebAPI.Controllers
{
    public class StudentsController : ApiController
    {
        CollegeEntities OE = new CollegeEntities();
        public IQueryable<Student> Get()
        {
            return OE.Students;
        }

        public Student Get(int id)
        {
            Student student = OE.Students.Find(id);
            return student;
        }

        public void Put(int id, Student student)
        {
            OE.Entry(student).State = System.Data.Entity.EntityState.Modified;
            OE.SaveChanges();
        }

        public void Delete(int id)
        {
            Student student = OE.Students.Find(id);
            OE.Students.Remove(student);
            OE.SaveChanges();
        }

        public void Post(Student student)
        {
            OE.Students.Add(student);
            OE.SaveChanges();
        }
    }
}
