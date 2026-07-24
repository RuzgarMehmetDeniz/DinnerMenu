using AutoMapper;
using DinnerMenuPostgreSQL.Context;
using DinnerMenuPostgreSQL.Dtos.CategoryDtos;
using DinnerMenuPostgreSQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DinnerMenuPostgreSQL.Service.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CategoryService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var value = _mapper.Map<Category>(createCategoryDto);
            await _context.Categories.AddAsync(value);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCategoryAsync(int id)
        {
            var value = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(value);
            await _context.SaveChangesAsync();
        }
        public async Task<List<ResultCategoryDto>> GetAllCategoriesAsync()
        {
            var values = await _context.Categories.ToListAsync();
            return _mapper.Map<List<ResultCategoryDto>>(values);
        }
        public async Task<GetCategoryByIdDto> GetCategoryByIdAsync(int id)
        {
            var value = await _context.Categories.FindAsync(id);
            return _mapper.Map<GetCategoryByIdDto>(value);
        }
        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var value = _mapper.Map<Category>(updateCategoryDto);
            _context.Categories.Update(value);
            await _context.SaveChangesAsync();
        }
        public async Task<Category> GetCategoryWithProductsAsync(int id)
        {
            return await _context.Categories
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.CategoryId == id && c.CategoryStatus);
        }
    }
}
