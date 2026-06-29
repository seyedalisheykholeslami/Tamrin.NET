using System.ComponentModel.DataAnnotations;

namespace Tamrin.Models;

public class Person
{
    public int Id { get; set; }
    public string UserName { get; set; } = null!;
    public string Password { get; set; }= null!;
    
}