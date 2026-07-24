using DinnerMenuPostgreSQL.Dtos.CategoryDtos;
using DinnerMenuPostgreSQL.Entities;

namespace DinnerMenuPostgreSQL.Service.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoriesAsync();
        Task<GetCategoryByIdDto> GetCategoryByIdAsync(int id);
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(int id);
        Task<Category> GetCategoryWithProductsAsync(int id);

    }
}
