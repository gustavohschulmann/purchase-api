using PurchaseApi.Domain.Entities;
using PurchaseApi.Domain.FiltersDb;
using PurchaseApi.Infra.Data.Repositories;

namespace PurchaseApi.Domain.Repositories;

public interface IPersonRepository
{
    Task<Person> GetByIdAsync(int id);
    Task<ICollection<Person>> GetPeopleAsync();
    Task<Person> CreateAsync(Person person);
    Task EditAsync(Person person);
    Task DeleteAsync(Person person);

    Task<PagedBaseResponse<Person>> GetPagedAsync(PersonFilterDb request);
}