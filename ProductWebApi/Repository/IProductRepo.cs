using ProductWebApi.Data;
using ProductWebApi.Model;

namespace ProductWebApi.Repository
{
    public interface IProductRepo
    {
        public Task<List<Product>> GetAllAsync();
        public Task<List<Product>> GetByCateAsync(int cateId);
        public Task<List<Product>> GetByNameAsync(string name);
        public Task<Product> GetByIdAsync(int id);
        public Task<bool> CreateAsync(ProductModel model);
        public Task<bool> UpdateAsync(int id, ProductModel model);
        public Task<bool> DeleteAsync(int id);
    }
}
