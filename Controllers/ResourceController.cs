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

public class ResourcesController : ControllerBase

{

    // GET api/resources

    [HttpGet]
    [EnableCors("AnotherPolicy")]
    public List<ResourceModel> Get()
    {

        return ResourceData.GetAllResources();

    }


    // GET api/resources/5

    [HttpGet("{id}")]
    [EnableCors("AnotherPolicy")]
    public ActionResult<string> Get(int id)

    {

        return "Welcome to AspSolution.net";

    }

    [HttpGet]
    [EnableCors("AnotherPolicy")]
    [Route("types")]
    public List<string> GetTypes()
    {
        return ResourceData.GetResourceTypes();
    }

    // POST api/resources

    [HttpPost]
    [EnableCors("AnotherPolicy")]
    public ResourceModel Post([FromBody] ResourceModel value)
    {
        return ResourceData.AddResource(value);
    }



    // PUT api/resources/5

    [HttpPut("{id}")]
    [EnableCors("AnotherPolicy")]
    public ResourceModel Put(string id, [FromBody] ResourceModel value)
    {
        return ResourceData.UpdateResource(id, value);
    }



    // DELETE api/resources/5

    [HttpDelete("{id}")]
    [EnableCors("AnotherPolicy")]
    public ResourceModel Delete(string id)
    {
        return ResourceData.DeleteResource(id);
    }

}