using UserWebApi.Data;
using UserWebApi.Model;

namespace UserWebApi.Repository
{
    public interface IUserRepo
    {
        public Task<List<User>> GetAllAsync();
        public Task<User> GetByIdAsync(int id);
        public Task<User> GetByPhoneNumAsync(string num);
        public Task<bool> CreateAsync(UserModel model);
        public Task<bool> UpdateAsync(int id,UserModel model);
        public Task<bool> DeleteAsync(int id);
    }
}
