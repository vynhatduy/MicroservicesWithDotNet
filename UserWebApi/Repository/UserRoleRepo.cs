using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserWebApi.Data;
using UserWebApi.Helper;
using UserWebApi.Model;

namespace UserWebApi.Repository
{
    public class UserRoleRepo:IUserRoleRepo
    {
        private readonly UserContext context;
        private readonly IMapper mapper;

        public UserRoleRepo(UserContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper=mapper;
        }

        public async Task<bool> CreateAsync(UserRoleModel model)
        {
            try
            {
                var result = HasherPassword.HashPass(model.Password.ToString().Trim());
                var pass = result.GetValueOrDefault("password");
                var salt = result.GetValueOrDefault("salt");
                if(pass == null||salt==null)
                {
                    return false;
                }
                var item = new UserRole
                {
                    UserId = model.UserId,
                    RoleId = 3,
                    Usename = model.Usename,
                    Password = pass,
                    Salt = salt
                };
                await context.UserRoles.AddAsync(item);
                await context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var item = await context.UserRoles!.FirstOrDefaultAsync(x => x.UserId == id);
                if (item == null) { return false; }
                context.UserRoles!.Remove(item);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public async Task<List<UserRole>> GetAllAsync()
        {
            return await context.UserRoles!.ToListAsync();
        }

        public async Task<UserRole> GetByUserIdAsync(int userId)
        {
            return await context.UserRoles!.FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<UserRole> GetByUsername(string username)
        {
            return await context.UserRoles!.FirstOrDefaultAsync(x => x.Usename.Equals(username));
        }

        public async Task<bool> UpdateAsync(int id, UserRoleModel model,int roleId)
        {
            try
            {
                var result = HasherPassword.HashPass(model.Password.Trim().ToString());
                var pass = result.GetValueOrDefault("password");
                var salt = result.GetValueOrDefault("salt");
                if (pass == null || salt == null)
                {
                    return false;
                }
                var item= await context.UserRoles!.FirstOrDefaultAsync(x => x.UserId == id);
                if (item == null)
                {
                    return false;
                }
                item.Salt = salt;
                item.Password = pass;
                item.RoleId = roleId;
                context.UserRoles.Update(item);
                await context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());   
                return false;
            }
        }
    }
}
