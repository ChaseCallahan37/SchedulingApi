using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using DataAccess;
using Microsoft.AspNetCore.Cors;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CourseController : ControllerBase
    {
        // GET: api/Course
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<CourseModel> Get()
        {
            return CourseData.GetAllCourses();
        }

        // GET: api/Course/5
        [EnableCors("AnotherPolicy")]

        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Course
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] CourseModel value)
        {
            CourseData.AddCourse(value);
        }

        // PUT: api/Course/55
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] CourseModel value)
        {
            CourseData.UpdateCourse(id, value);
        }

        // DELETE: api/Course/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            CourseData.DeleteCourse(id);
        }
    }
}
