using Microsoft.AspNetCore.Mvc;
using Tamrin.DTOs;
using Tamrin.Models;
using Tamrin.Services;

namespace Tamrin.Controllers;
[ApiController]
[Route("[controller]")]
public class PersonController(PersonService service) : ControllerBase
{
    [HttpGet]
    [Route("/Persons")]
    public ActionResult<IEnumerable<Person>> GetAll()
    {
       var result = service.GetAll();
       if (result.IsSuccess)
       {
           return Ok(result.Data);
       }
       else
       {
           return StatusCode(500);
       }
    }
    [HttpGet("{id:int}")]
    public ActionResult<Person> GetById(int id)
    {
       var result = service.GetById(id);
       if (result.IsSuccess)
       {
           return Ok(result.Data);
       }
       else
       {
           return StatusCode(500);
       }
    }
    [HttpPost]
    public ActionResult Insert([FromBody] PersonDto dto)
    {
       var result = service.Insert(dto);
       if (result.IsSuccess)
       {
           return Ok();
       }
       else
       {
           return StatusCode(500);
       }
    }
    [HttpPut("{id:int}")]
    public ActionResult Update(int id,[FromBody] PersonDto dto)
    {
        var result = service.Update(id,dto);
        if (result.IsSuccess)
        {
            return Ok();
        }
        else
        {
            return StatusCode(500);
        }
    }
    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var result = service.Delete(id);
        if (result.IsSuccess)
        {
            return Ok();
        }
        else
        {
            return StatusCode(500);
        }
    }
}