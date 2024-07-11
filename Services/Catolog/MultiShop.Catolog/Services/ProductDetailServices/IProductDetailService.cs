using MultiShop.Catolog.Dtos.ProductDetailDtos;

namespace MultiShop.Catolog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task DeleteProductDetailAsync(string id);
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
    }
}
