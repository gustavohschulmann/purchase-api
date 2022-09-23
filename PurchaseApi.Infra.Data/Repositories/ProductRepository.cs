using Microsoft.EntityFrameworkCore;
using PurchaseApi.Domain.Entities;
using PurchaseApi.Domain.Repositories;
using PurchaseApi.Infra.Data.Context;

namespace PurchaseApi.Infra.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _dbContext;
    
    public ProductRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Product> GetByIdAsync(int id)
    {
        return await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<ICollection<Product>> GetProductAsync()
    {
        return await _dbContext.Products.ToListAsync();
    }

    public async Task<Product> CreateAsync(Product product)
    {
        _dbContext.Add(product);
        await _dbContext.SaveChangesAsync();
        return product;
    }

    public async Task EditAsync(Product product)
    {
        _dbContext.Update(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Product product)
    {
        _dbContext.Remove(product);
        await _dbContext.SaveChangesAsync();
    }
}