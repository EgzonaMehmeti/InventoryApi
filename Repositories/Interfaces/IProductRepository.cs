using InventoryApi.Models;

namespace InventoryApi.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<(List<Product> Items, int TotalItems)> GetPagedAsync(int page, int pageSize, string? name, string? category);

        Task<Product?> GetByIdAsync(int id);

        Task<Product> AddAsync(Product product);

        Task UpdateAsync(Product product);

        Task DeleteAsync(Product product);
    }
}
