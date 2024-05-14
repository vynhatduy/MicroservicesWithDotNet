using InventoryWebApi.Data;
using InventoryWebApi.Model;

namespace InventoryWebApi.Repository
{
    public interface IProductRepo
    {
        public Task<List<Product>> GetAllAsync();
        public Task<List<Product>> GetByNameAsync(string name);
        public Task<List<Product>> GetByNumAsync(int num);
        public Task<Product> GetByIdAsync(int id);
        public Task<bool> CreateAsync(ProductModel model);
        public Task<bool> UpdateAsync(int id,ProductModel model);
        public Task<bool> Delete(int id);

    }
}
