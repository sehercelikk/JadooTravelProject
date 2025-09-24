using AutoMapper;
using JadooTravel.Dtos.CategoryDtos;
using JadooTravel.Entities;
using JadooTravel.Settings;
using MongoDB.Driver;

namespace JadooTravel.Services.CategoryServices;

public class CategoryService : ICategoryService
{
    private readonly IMongoCollection<Category> _categories;
    private readonly IMapper _mapper;

    public CategoryService(IMapper mapper,IDatabaseSetting _databaseSetting)
    {
        var client= new MongoClient(_databaseSetting.ConnectionString);
        var database = client.GetDatabase(_databaseSetting.DatabaseName);
        _categories = database.GetCollection<Category>(_databaseSetting.CategoryCollectionName);

        _mapper = mapper;
    }

    public async Task CreateCategoryAsync(CreateCategoryDto model)
    {
        var value = _mapper.Map<Category>(model);
        await _categories.InsertOneAsync(value);
    }

    public async Task DeleteCategoryAsync(string id)
    {
        await _categories.DeleteOneAsync(x=>x.Id==id);
    }

    public async Task<List<ResultCategoryDto>> GetAllCategoriesAsync()
    {
        var values = await _categories.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultCategoryDto>>(values);
    }

    public async Task<GetCategoryByIdDto> GetCategoryByIdAsync(string id)
    {
        var value = await _categories.Find(a => a.Id == id).FirstOrDefaultAsync();
        return _mapper.Map<GetCategoryByIdDto>(value);
    }

    public async Task UpdateCategoryAsync(UpdateCategoryDto model)
    {
        var value=_mapper.Map<Category>(model);
        await _categories.FindOneAndReplaceAsync(a => a.Id == model.Id, value);

    }
}
