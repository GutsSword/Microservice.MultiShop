using MultiShop.Catolog.Dtos.CategoryDtos;
using System.Linq.Expressions;

namespace MultiShop.Catolog.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id);
        Task CreateCategoryAsync(CreateCategeoryDto createCategeoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(string id);
    }
}
