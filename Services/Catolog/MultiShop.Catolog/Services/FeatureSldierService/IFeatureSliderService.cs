using MultiShop.Catolog.Dtos.FeatureSliderDtos;
using MultiShop.Catolog.Dtos.ProductDetailDtos;

namespace MultiShop.Catolog.Services.FeatureSldierService
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSliderDto>> GetAllFeatureSlider();
        Task<GetFeatureSliderByIdDto> GetByIdFeatureSliderAsync(string id);
        Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto);
        Task DeleteFeatureSliderAsync(string id);
        Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto);
    }
}
