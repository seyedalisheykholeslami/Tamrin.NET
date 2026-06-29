using Tamrin.DTOs;
using Tamrin.Interfaces;
using Tamrin.Models;
using Tamrin.Repositories;
using Tamrin.Share;

namespace Tamrin.Services;

public class PersonService(IRepo<Person> repo)
{
    
     static int _id = 0;
    public OperationResult Insert(PersonDto model)
    {
        
        var person = model.InsertDtoToPerson();
        person.Id = ++_id;
        var result = person.PersonValidator();
        if (result.IsSuccess)
            repo.Insert(person);
        return result;
        

    }

    public OperationResult Update(int id, PersonDto model)
    {
        var person = model.UpdateDtoToPerson(id);
        var result = person.PersonValidator();
        if (result.IsSuccess)
            repo.Update(person);
        return result;
    }

    public OperationResult Delete(int id)
    {
        var person = repo.GetById(id);
        if (person != null)
        {
            repo.Delete(person);
            return OperationResult.Success();
        }
        else
        {
            return OperationResult.Feilure("کاربر یافت نشد");
        }
    }

    public OperationResult<Person> GetById(int id)
    {
        var person = repo.GetById(id);
        if (person != null)
            return OperationResult<Person>.Success(person);
        else
            return OperationResult<Person>.Feilure("کاربر پیدا نشد");

    }

    public OperationResult<List<Person>> GetAll()
    {
        return OperationResult<List<Person>>.Success( repo.GetAll());

    }
}