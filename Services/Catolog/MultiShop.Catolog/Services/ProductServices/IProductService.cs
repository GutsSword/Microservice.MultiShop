using MultiShop.Catolog.Dtos.CategoryDtos;
using MultiShop.Catolog.Dtos.ProductDtos;
using MultiShop.Catolog.Entities;

namespace MultiShop.Catolog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<GetByIdProductDto> GetByIdProductAsync(string id);
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);

        Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryAsync();
        Task<List<ResultProductsByCategoryDto>> GetProductListByCategoryAsync(string categoryId);

    }
}
