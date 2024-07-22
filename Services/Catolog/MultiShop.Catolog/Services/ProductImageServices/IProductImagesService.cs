using MultiShop.Catolog.Dtos.CategoryDtos;
using MultiShop.Catolog.Dtos.ProductImagesDtos;

namespace MultiShop.Catolog.Services.ProductImageServices
{
    public interface IProductImagesService
    {
        Task<List<ResultProductImageDto>> GetAllProductImageAsync();
        Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id);
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task DeleteProductImageAsync(string id);

        Task<GetByIdProductImageDto> GetByProductIdProductImagesAsync(string id);

    }
}
