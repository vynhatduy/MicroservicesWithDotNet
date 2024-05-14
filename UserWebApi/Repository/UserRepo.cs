using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserWebApi.Data;
using UserWebApi.Model;

namespace UserWebApi.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly UserContext context;
        private readonly IMapper mapper;

        public UserRepo(UserContext context, IMapper mapper)
        {
            this.context = context; 
            this.mapper = mapper;
        }
        public async Task<bool> CreateAsync(UserModel model)
        {
            try
            {
                await context.Users!.AddAsync(mapper.Map<User>(model));
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;   
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var item = await context.Users!.FirstOrDefaultAsync(x => x.Id == id);
                if (item == null)
                {
                    return false;
                }
                context.Users.Remove(item);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await context.Users!.ToListAsync();
        }

        public Task<User> GetByIdAsync(int id)
        {
            return context.Users!.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public Task<User> GetByPhoneNumAsync(string num)
        {
            return context.Users!.FirstOrDefaultAsync(x=>x.SDT.Equals(num));
        }

        public async Task<bool> UpdateAsync(int id, UserModel model)
        {
            try
            {
                var item = await context.Users!.FirstOrDefaultAsync(x => x.Id == id);
                if (item == null)
                {
                    return false;
                }
                item.HoTen = model.HoTen;
                item.SDT = model.SDT;
                item.DiaChi = model.DiaChi;
                context.Users.Update(item);
                await context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString() ); 
                return false;
            }
        }
    }
}
