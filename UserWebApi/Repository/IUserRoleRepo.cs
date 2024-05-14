using UserWebApi.Data;
using UserWebApi.Model;

namespace UserWebApi.Repository
{
    public interface IUserRoleRepo
    {
        public Task<List<UserRole>> GetAllAsync();
        public Task<UserRole> GetByUserIdAsync(int userId);
        public Task<UserRole> GetByUsername(string username);
        public Task<bool> CreateAsync(UserRoleModel model);
        public Task<bool> UpdateAsync(int id, UserRoleModel model,int roleId);
        public Task<bool> DeleteAsync(int id);
    }
}
