using OrderWebApi.Data;
using OrderWebApi.Model;

namespace OrderWebApi.Repository
{
    public interface IOrderDetailRepo
    {
        public Task<List<OrderDetail>> GetAllAsync();
        public Task<List<OrderDetail>> GetByOrderIdAsync(int orderId);
        public Task<List<OrderDetail>> GetByProductIdAsync(int productId);

        public Task<bool> CreateAsync(OrderDetailModel model);
        public Task<bool> UpdateAsync(int id, OrderDetailModel model);
        public Task<bool> DeleteAsync(int id);
        public Task<bool> DeleteItemProductAsync(int productId);
    }
}
