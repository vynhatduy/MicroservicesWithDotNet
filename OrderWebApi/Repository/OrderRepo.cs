using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderWebApi.Data;
using OrderWebApi.Model;

namespace OrderWebApi.Repository
{
    public class OrderRepo : IOrderRepo
    {
        private readonly OrderContext context;
        private readonly IMapper mapper;

        public OrderRepo(OrderContext context,IMapper mapper) {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<bool> CreateAsync(OrderModel model)
        {
            try
            {
                await context.Orders.AddAsync(mapper.Map<Order>(model));
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var item = await context.Orders!.FirstOrDefaultAsync(x => x.Id == id);
                if (item == null)
                {
                    return false;
                }
                context.Remove(item);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString() );
                return false;
            }
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await context.Orders!.ToListAsync();
        }

        public async Task<List<Order>> GetByCreateDateAsync(DateTime ngay)
        {
            return await context.Orders!.Where(x=>x.Ngay.Equals(ngay)).ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await context.Orders!.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Order>> GetByUserIdAsync(int userId)
        {
            return await context.Orders!.Where(x=>x.UserId== userId).ToListAsync();
        }

        public async Task<bool> UpdateAsync(int id, OrderModel model)
        {
            try
            {
                var item = await context.Orders!.FirstOrDefaultAsync(x => x.Id == id);
                if (item == null)
                {
                    return false;
                }
                item.UserId = model.UserId;
                item.Ngay=model.Ngay;
                item.TongTien=model.TongTien;   
                context.Orders!.Update(item);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
