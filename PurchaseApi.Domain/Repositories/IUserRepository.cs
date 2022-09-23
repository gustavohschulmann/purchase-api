using PurchaseApi.Domain.Entities;

namespace PurchaseApi.Domain.Repositories;

public interface IUserRepository
{
    Task<User> GetUserByEmailAndPasswordAsync(string email, string password);
}