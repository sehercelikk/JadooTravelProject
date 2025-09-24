using JadooTravel.Dtos.CategoryDtos;

namespace JadooTravel.Services.CategoryServices;

public interface ICategoryService
{
    Task<List<ResultCategoryDto>> GetAllCategoriesAsync();
    Task CreateCategoryAsync(CreateCategoryDto model);
    Task UpdateCategoryAsync(UpdateCategoryDto model);
    Task DeleteCategoryAsync(string id);
    Task<GetCategoryByIdDto> GetCategoryByIdAsync(string id);
}
