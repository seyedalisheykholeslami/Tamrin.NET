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
       return Ok(service.GetAll());
       
    }
    [HttpGet("{id:int}")]
    public ActionResult<Person> GetById(int id)
    {
        return Ok(service.GetById(id)); 
       
    }

    [HttpPost]
    public ActionResult Insert([FromBody] PersonDto dto)
    {
        service.Insert(dto);
        return Ok();
    }

    [HttpPut("{id:int}")]
    public ActionResult Update(int id,[FromBody] PersonDto dto)
    {
        service.Update(id, dto);
            return Ok();
    }
    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
      service.Delete(id);
      
            return Ok();
       
    }
}