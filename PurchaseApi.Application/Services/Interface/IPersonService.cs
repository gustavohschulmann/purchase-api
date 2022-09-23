using PurchaseApi.Application.DTOs;
using PurchaseApi.Domain.FiltersDb;
using PurchaseApi.Infra.Data.Repositories;

namespace PurchaseApi.Application.Services.Interface;

public interface IPersonService
{
    Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDto);
    Task<ResultService<ICollection<PersonDTO>>> GetAsync();
    Task<ResultService<PersonDTO>> GetByIdAsync(int id);
    Task<ResultService> UpdateAsync(PersonDTO personDto);
    Task<ResultService> DeleteAsync(int id);
    Task<ResultService<PagedBaseResponseDTO<PersonDTO>>> GetPagedAsync(PersonFilterDb personFilterDb);
}