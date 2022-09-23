using AutoMapper;
using PurchaseApi.Application.DTOs;
using PurchaseApi.Domain.Entities;

namespace PurchaseApi.Application.Mappings;

public class DtoToDomainMapper : Profile
{
    public DtoToDomainMapper()
    {
        CreateMap<PersonDTO, Person>();
    }
}