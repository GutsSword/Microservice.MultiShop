using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catolog.Dtos.CategoryDtos;
using MultiShop.Catolog.Entities;
using MultiShop.Catolog.Settings;
using System.Linq.Expressions;

namespace MultiShop.Catolog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> categoryCollection;
        private readonly IDatabaseSettings databaseSettings;
        private readonly IMapper mapper;

        public CategoryService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            this.mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategeoryDto createCategeoryDto)
        {
            var value = mapper.Map<Category>(createCategeoryDto);
            await categoryCollection.InsertOneAsync(value);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await categoryCollection.DeleteOneAsync(x => x.CategoryId == id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var values = await categoryCollection.Find(x => true).ToListAsync();
            var resultCategoryDto = mapper.Map<List<ResultCategoryDto>>(values);
            
            return resultCategoryDto; 
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var values = await categoryCollection.Find(x=>x.CategoryId == id).FirstOrDefaultAsync();
            var getByIdCategoryDto = mapper.Map<GetByIdCategoryDto>(values);

            return getByIdCategoryDto;
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var values = mapper.Map<Category>(updateCategoryDto);
            await categoryCollection.FindOneAndReplaceAsync(x => x.CategoryId == updateCategoryDto.CategoryId, values);
        }
    }
}
