using InventoryApi.DTOs;
using InventoryApi.Models;
using InventoryApi.Repositories.Interfaces;
using InventoryApi.Services.Interfaces;

namespace InventoryApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResultDto<ProductResponseDto>> GetPagedAsync(int page, int pageSize, string? name, string? category)
        {
            var (products, totalItems) = await _repository.GetPagedAsync(page, pageSize, name, category);

            var totalPages = (int)Math.Ceiling(
                totalItems / (double)pageSize);

            return new PagedResultDto<ProductResponseDto>
            {
                Items = products
                    .Select(MapToResponseDto)
                    .ToList(),

                Page = page,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = totalPages
            };
        }

        public async Task<ProductResponseDto?> GetByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
            {
                return null;
            }

            return MapToResponseDto(product);
        }

        public async Task<ProductResponseDto> CreateAsync(CreateProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name.Trim(),
                Description = dto.Description?.Trim(),
                Price = dto.Price,
                QuantityInStock = dto.QuantityInStock,
                Category = dto.Category?.Trim(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var createdProduct = await _repository.AddAsync(product);

            return MapToResponseDto(createdProduct);
        }

        public async Task<bool> UpdateAsync(int id, UpdateProductDto dto)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
            {
                return false;
            }

            product.Name = dto.Name.Trim();
            product.Description = dto.Description?.Trim();
            product.Price = dto.Price;
            product.QuantityInStock = dto.QuantityInStock;
            product.Category = dto.Category?.Trim();
            product.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(product);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
            {
                return false;
            }

            await _repository.DeleteAsync(product);

            return true;
        }

        private static ProductResponseDto MapToResponseDto(Product product)
        {
            return new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                QuantityInStock = product.QuantityInStock,
                Category = product.Category,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt
            };
        }
    }
}
