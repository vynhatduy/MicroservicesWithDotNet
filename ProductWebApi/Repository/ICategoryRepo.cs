using ProductWebApi.Data;
using ProductWebApi.Model;

namespace ProductWebApi.Repository
{
    public interface ICategoryRepo
    {
        public Task<List<Category>> GetAllAsync();
        public Task<Category> GetByIdAsync(int id);
        public Task<bool> CreateAsync(CategoryModel model);
        public Task<bool> UpdateAsync(int id, CategoryModel model);
        public Task<bool> DeleteAsync(int id);
    }
}
