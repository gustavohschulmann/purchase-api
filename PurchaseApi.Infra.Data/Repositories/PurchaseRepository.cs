using Microsoft.EntityFrameworkCore;
using PurchaseApi.Domain.Entities;
using PurchaseApi.Domain.Repositories;
using PurchaseApi.Infra.Data.Context;

namespace PurchaseApi.Infra.Data.Repositories;

public class PurchaseRepository : IPurchaseRepository
{
    private readonly ApplicationDbContext _dbContext;
    
    public PurchaseRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Purchase> GetByIdAsync(int id)
    {
        return await _dbContext.Purchases.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<ICollection<Purchase>> GetPurchaseAsync()
    {
        return await _dbContext.Purchases.ToListAsync();
    }

    public async Task<Purchase> CreateAsync(Purchase purchase)
    {
        _dbContext.Add(purchase);
        await _dbContext.SaveChangesAsync();
        return purchase;
    }

    public async Task EditAsync(Purchase purchase)
    {
        _dbContext.Update(purchase);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Purchase purchase)
    {
        _dbContext.Remove(purchase);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<ICollection<Purchase>> GetByPersonIdAsync(int personId)
    {
        return await _dbContext.Purchases
            .Include(x => x.Person)
            .Include(x => x.Product)
            .Where(x => x.PersonId == personId).ToListAsync();
    }
    
    public async Task<ICollection<Purchase>> GetByProductIdAsync(int productId)
    {
        return await _dbContext.Purchases
            .Include(x => x.Product)
            .Include(x => x.Person)
            .Where(x => x.ProductId == productId).ToListAsync();
    }
}