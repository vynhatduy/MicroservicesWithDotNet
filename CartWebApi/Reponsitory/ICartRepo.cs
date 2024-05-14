using CartWebApi.Data;

namespace CartWebApi.Reponsitory
{
    public interface ICartRepo
    {
        public Task<List<Cart>> GetCartByUsername(string username);
        public Task<bool> Create(Cart model);
        public Task<bool> DeleteByUsername(string username);
        public Task<bool> DeleteByProductId(string username,int productId);

    }
}
