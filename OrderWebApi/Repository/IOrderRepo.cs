using OrderWebApi.Data;
using OrderWebApi.Model;

namespace OrderWebApi.Repository
{
    public interface IOrderRepo
    {
        public Task<List<Order>> GetAllAsync();
        public Task<List<Order>> GetByUserIdAsync(int userId);
        public Task<Order> GetByIdAsync(int id);
        public Task<List<Order>> GetByCreateDateAsync(DateTime ngay);

        public Task<bool> CreateAsync(OrderModel model);
        public Task<bool> UpdateAsync(int id,OrderModel model);
        public Task<bool> DeleteAsync(int id);
        
    }
}
