using Microsoft.EntityFrameworkCore;
using PurchaseApi.Domain.Entities;
using PurchaseApi.Domain.FiltersDb;
using PurchaseApi.Domain.Repositories;
using PurchaseApi.Infra.Data.Context;

namespace PurchaseApi.Infra.Data.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly ApplicationDbContext _dbContext;
    
    public PersonRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Person> GetByIdAsync(int id)
    {
        var result = await _dbContext.People.FirstOrDefaultAsync(x => x.Id == id);
        return result;
    }

    public async Task<ICollection<Person>> GetPeopleAsync()
    {
        return await _dbContext.People.ToListAsync();
    }

    public async Task<Person> CreateAsync(Person person)
    {
        _dbContext.Add(person);
        await _dbContext.SaveChangesAsync();
        return person;
    }

    public async Task EditAsync(Person person)
    {
        _dbContext.Update(person);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Person person)
    {
        _dbContext.Remove(person);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<PagedBaseResponse<Person>> GetPagedAsync(PersonFilterDb request)
    {
        var people = _dbContext.People.AsQueryable();
        if (!string.IsNullOrEmpty(request.Name))
            people = people.Where(x => x.Name.Contains(request.Name));

        return await PagedBaseResponseHelper.GetResponseAsync<PagedBaseResponse<Person>, Person>(people, request);
    }
}