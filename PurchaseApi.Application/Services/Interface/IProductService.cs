using PurchaseApi.Application.DTOs;

namespace PurchaseApi.Application.Services.Interface;

public interface IPersonService
{
    Task<ResultService<PersonDTO>> CreateAsync(Product personDto);
    Task<ResultService<ICollection<PersonDTO>>> GetAsync();
    Task<ResultService<PersonDTO>> GetByIdAsync(int id);
    Task<ResultService> UpdateAsync(PersonDTO personDto);
    Task<ResultService> DeleteAsync(int id);
}