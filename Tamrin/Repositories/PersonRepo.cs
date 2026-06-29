using Tamrin.Models;
using Tamrin.Interfaces;

namespace Tamrin.Repositories;

public class PersonRepo : IRepo<Person>
{
    private static readonly List<Person> Persons = [];
    public void Insert(Person person)
    {
        Persons.Add(person);
    }

    public void Update(Person person)
    {
       var personUpdate =  Persons.Single(p => p.Id == person.Id);
       personUpdate = person; 
    }
    

    public void Delete(Person person)
    {
        Persons.Remove(person);
    }

    public Person GetById(int id)
    {
       return  Persons.FirstOrDefault(p => p.Id == id);
        
    }

    public List<Person> GetAll()
    {
        return  Persons;
    }
}