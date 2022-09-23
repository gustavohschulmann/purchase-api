using PurchaseApi.Domain.Entities;

namespace PurchaseApi.Domain.Repositories;

public interface IProductRepository
{
    Task<Product> GetByIdAsync(int id);
    Task<ICollection<Product>> GetProductAsync();
    Task<Product> CreateAsync(Product person);
    Task EditAsync(Product person);
    Task DeleteAsync(Product person);
}