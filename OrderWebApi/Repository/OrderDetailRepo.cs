using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderWebApi.Data;
using OrderWebApi.Model;

namespace OrderWebApi.Repository
{
    public class OrderDetailRepo : IOrderDetailRepo
    {
        private readonly OrderContext context;
        private readonly IMapper mapper;

        public OrderDetailRepo(OrderContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper=mapper;
        }
        public async Task<bool> CreateAsync(OrderDetailModel model)
        {
            try
            {
                var item = await context.Details!.FirstOrDefaultAsync(x => x.ProductId == model.ProductId);
                if (item != null)
                {
                    this.UpdateAsync(model.orderId, model);
                    return true;
                }
                await context.Details!.AddAsync(mapper.Map<OrderDetail>(model));
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
                var item = await context.Details!.Where(x => x.orderId == id).ToListAsync();
                if (item != null)
                {
                    return false;
                }
                context.Details!.RemoveRange(item);
                await context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public async Task<bool> DeleteItemProductAsync(int productId)
        {
            try
            {
                var item = await context.Details!.FirstOrDefaultAsync(x => x.ProductId == productId);
                if (item != null)
                {
                    return false;
                }
                context!.Remove(item);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public async Task<List<OrderDetail>> GetAllAsync()
        {
            return await context.Details!.ToListAsync();
        }

        public async Task<List<OrderDetail>> GetByOrderIdAsync(int orderId)
        {
            return await context.Details!.Where(x=>x.orderId== orderId).ToListAsync();
        }

        public async Task<List<OrderDetail>> GetByProductIdAsync(int productId)
        {
            return await context.Details!.Where(x => x.ProductId == productId).ToListAsync();
        }

        public async Task<bool> UpdateAsync(int id, OrderDetailModel model)
        {
            try
            {
                var item = await context.Details!.FirstOrDefaultAsync(x => x.orderId == id);
                var currentItem=await context.Details!.FirstOrDefaultAsync(x=>x.ProductId==model.ProductId);
                if (item == null)
                {
                    return false;
                }
                if (currentItem == null)
                {
                    this.CreateAsync(model);
                    return true;
                }
                else
                {
                    item.SoLuong = model.SoLuong;
                    item.ThanhTien = model.ThanhTien;
                    context.Details!.Update(item);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
