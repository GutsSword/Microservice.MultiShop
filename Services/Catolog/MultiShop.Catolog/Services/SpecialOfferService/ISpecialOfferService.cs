using MultiShop.Catolog.Dtos.ProductDtos;
using MultiShop.Catolog.Dtos.SpecialOfferDtos;

namespace MultiShop.Catolog.Services.SpecialOfferService
{
    public interface ISpecialOfferService
    {
        Task<List<ResultSpecialOfferDto>> GetAllSpecialOffersAsync();
        Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string id);
        Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto);
        Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto);
        Task DeleteSpecialOfferAsync(string id);
    }
}
