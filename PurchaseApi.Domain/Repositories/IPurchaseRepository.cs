using PurchaseApi.Domain.Entities;

namespace PurchaseApi.Domain.Repositories;

public interface IPurchaseRepository
{
    Task<Purchase> GetByIdAsync(int id);
    Task<ICollection<Purchase>> GetPurchaseAsync();
    Task<Purchase> CreateAsync(Purchase purchase);
    Task EditAsync(Purchase purchase);
    Task DeleteAsync(Purchase purchase);
    Task<ICollection<Purchase>> GetByPersonIdAsync(int personId);
    Task<ICollection<Purchase>> GetByProductIdAsync(int productId);
}