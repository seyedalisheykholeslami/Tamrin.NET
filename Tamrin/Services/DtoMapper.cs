using Tamrin.DTOs;
using Tamrin.Models;

namespace Tamrin.Services;

public static class DtoMapper
{
    public static Person InsertDtoToPerson(this PersonDto dto)
    {
        return new Person
        {
            UserName =  dto.UserName,
            Password =  dto.Password,
            
            
        };
    }

    public static Person UpdateDtoToPerson(this PersonDto dto,int id)
    {
        return new Person
        {
            Id =  id,
            UserName =  dto.UserName,
            Password =  dto.Password,
        };
        
    }
}