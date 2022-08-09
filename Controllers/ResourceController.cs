using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using DataAccess;
using Microsoft.AspNetCore.Cors;
using DataAccess;

[Route("api/[controller]")]

[ApiController]

public class ResourceController : ControllerBase

{

    // GET api/resource

    [HttpGet]
    [EnableCors("AnotherPolicy")]
    public List<ResourceModel> Get()
    {

        return ResourceData.GetAllResources();

    }



    // GET api/resource/5

    [HttpGet("{id}")]
    [EnableCors("AnotherPolicy")]
    public ActionResult<string> Get(int id)

    {

        return "Welcome to AspSolution.net";

    }



    // POST api/resource

    [HttpPost]
    [EnableCors("AnotherPolicy")]
    public ResourceModel Post([FromBody] ResourceModel value)
    {
        return ResourceData.AddResource(value);
    }



    // PUT api/resource/5

    [HttpPut("{id}")]
    [EnableCors("AnotherPolicy")]
    public ResourceModel Put(string id, [FromBody] ResourceModel value)
    {
        return ResourceData.UpdateResource(id, value);
    }



    // DELETE api/resource/5

    [HttpDelete("{id}")]
    [EnableCors("AnotherPolicy")]
    public ResourceModel Delete(string id)
    {
        return ResourceData.DeleteResource(id);
    }

}