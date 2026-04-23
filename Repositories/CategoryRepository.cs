using FinShark.API.Data;
using FinShark.API.Interfaces;
using FinShark.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FinShark.API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext dbContext;

        public CategoryRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Category> AddAsync(Category category)
        {
            dbContext.Categories.Add(category);
            await dbContext.SaveChangesAsync();
            return category;
        }

        public async Task DeleteAsync(Category category)
        {
            dbContext.Categories.Remove(category);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAllAsync(string userId)
        {
            return await dbContext.Categories.Where(x => x.ApplicationUserId == userId).OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id, string userId)
        {
            return await dbContext.Categories.FirstOrDefaultAsync(x => x.ApplicationUserId == userId && x.CategoryId == id);
        }

        public async Task UpdateAsync(Category category)
        {
            dbContext.Categories.Update(category);
            await dbContext.SaveChangesAsync();
        }
    }
}
