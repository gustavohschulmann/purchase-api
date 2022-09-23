using AutoMapper;
using PurchaseApi.Application.DTOs;
using PurchaseApi.Domain.Entities;

namespace PurchaseApi.Application.Mappings;

public class DomainToDtoMapper : Profile
{
    public DomainToDtoMapper()
    {
        CreateMap<Person, PersonDTO>();
    }
}