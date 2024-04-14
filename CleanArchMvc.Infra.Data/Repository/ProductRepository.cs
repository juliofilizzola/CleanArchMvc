using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repository;

public class ProductRepository(ApplicationDbContext context) : IProductRepository {

    private ApplicationDbContext _productContext = context;

    public async Task<IEnumerable<Product>> GetProductsAsync() {
        return await _productContext.Products.ToListAsync();
    }

    public async Task<Product> GetByIdAsync(int? id) {
        return await _productContext.Products.FindAsync(id);
    }

    public async Task<Product> GetProductCategoryAsync(int? id) {
        return await _productContext.Products.Include(c => c.Category).SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Product> CreateAsync(Product product) {
        _productContext.Products.Add(product);
        await _productContext.SaveChangesAsync();
        return product;
    }

    public async Task<Product> UpdateAsync(Product product) {
        _productContext.Products.Update(product);
        await _productContext.SaveChangesAsync();
        return product;
    }

    public async Task<Product> RemoveAsync(Product product) {
        _productContext.Products.Remove(product);
        await _productContext.SaveChangesAsync();
        return product;
    }
}