using Tamrin.DTOs;
using Tamrin.Interfaces;
using Tamrin.Models;
using Tamrin.Repositories;
using Tamrin.Share;

namespace Tamrin.Services;

public class PersonService(IRepo<Person> repo)
{
    
     static int _id = 0;
    public void Insert(PersonDto model)
    {
        
        var person = model.InsertDtoToPerson();
        person.Id = ++_id;
        person.PersonValidator();
            repo.Insert(person);
        
        

    }

    public void Update(int id, PersonDto model)
    {
        var person = model.UpdateDtoToPerson(id);
         person.PersonValidator();
            repo.Update(person);
    }

    public void Delete(int id)
    {
        var person = repo.GetById(id);
        if (person == null)
            throw new UnauthorizedAccessException("کاربر پیدا نشد");
        repo.Delete(person);
          
       
    }

    public Person GetById(int id)
    {
        var person = repo.GetById(id);
        return person == null ? throw new UnauthorizedAccessException("کاربر پیدا نشد") : repo.GetById(id);
    }

    public List<Person> GetAll()
    {
        return repo.GetAll();

    }
}