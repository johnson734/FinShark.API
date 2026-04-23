using FinShark.API.Models;

namespace FinShark.API.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync(string userId  );
        Task<Category> GetByIdAsync( int id, string userId);
        Task<Category> AddAsync(Category category );
        Task UpdateAsync(Category category);
        Task DeleteAsync(Category category); 

    }
}
