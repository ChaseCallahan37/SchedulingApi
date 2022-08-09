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

    public class EventController : ControllerBase
    {
        // GET: api/Course
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<EventModel> Get()
        {
            return EventData.GetAllEvents();
        }

        // GET: api/Event/5
        [EnableCors("AnotherPolicy")]

        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Event
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public EventModel Post([FromBody] EventModel value)
        {
            return EventData.AddEvent(value);
        }

        // PUT: api/Event/55
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public EventModel Put(string id, [FromBody] EventModel value)
        {
            return EventData.UpdateEvent(id, value);
        }

        // DELETE: api/Event/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public EventModel Delete(string id)
        {
            return EventData.DeleteEvent(id);
        }
    }
}