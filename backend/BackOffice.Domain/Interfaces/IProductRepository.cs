using BackOffice.Domain.Entities;


namespace BackOffice.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Guid id);
        Task<Product?> GetByIdAsync(Guid id);
        Task<List<Product>> GetAllAsync();
    }
}
