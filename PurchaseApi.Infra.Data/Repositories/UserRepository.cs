using Microsoft.EntityFrameworkCore;
using PurchaseApi.Domain.Entities;
using PurchaseApi.Domain.Repositories;
using PurchaseApi.Infra.Data.Context;

namespace PurchaseApi.Infra.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
    }
}