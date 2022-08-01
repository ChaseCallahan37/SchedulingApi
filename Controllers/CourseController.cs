using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Models;
using Database;
using DataAccess;

//Change

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
        public CourseModel Post([FromBody] CourseModel value)
        {
            return CourseData.AddCourse(value);
        }

        // PUT: api/Course/55
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public CourseModel Put(string id, [FromBody] CourseModel value)
        {
            return CourseData.UpdateCourse(id, value);
        }

        // DELETE: api/Course/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public CourseModel Delete(string id)
        {
            return CourseData.DeleteCourse(id);
        }
    }
}
