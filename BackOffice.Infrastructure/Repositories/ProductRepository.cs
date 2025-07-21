

using BackOffice.Domain.Entities;
using BackOffice.Domain.Interfaces;
using BackOffice.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BackOffice.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;
        public ProductRepository(ProductDbContext context) => _context = context;

        public async Task AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Products.FindAsync(id);
            if (entity != null)
            {
                _context.Products.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public Task<Product?> GetByIdAsync(Guid id) => _context.Products.FindAsync(id).AsTask();
        public Task<List<Product>> GetAllAsync()
        {
            try
            {
                return _context.Products.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                // You can use a logging framework like Serilog, NLog, etc.
                throw new ApplicationException("An error occurred while retrieving products.", ex);
            }

        }
    }
}
