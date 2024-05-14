using CartWebApi.Data;
using CartWebApi.Reponsitory;
using Microsoft.EntityFrameworkCore;

namespace CartWebApi
{
    public class CartRepo : ICartRepo
    {
        private readonly CartContext context;

        public CartRepo(CartContext context) { this.context = context; }
        public async Task<bool> Create(Cart model)
        {
            try
            {
                var item = await context.Carts!.FirstOrDefaultAsync(x => x.Username == model.Username&&x.productId==model.productId);
                if (item == null)
                {
                    await context.Carts.AddAsync(model);
                }
                else
                {
                    item.SoLuong += model.SoLuong;
                    item.Gia = model.Gia;
                    context.Carts.Update(item);
                }
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteByProductId(string username,int productId)
        {
            try
            {
                var item = await context.Carts!.FirstOrDefaultAsync(x => x.Username == username && x.productId == productId);
                if (item == null)
                {
                    return false;
                }
                    context.Carts!.Remove(item);
                await context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteByUsername(string username)
        {
            try
            {
                var item = await context.Carts!.Where(x => x.Username == username).ToListAsync();
                if (item == null)
                {
                    return false;
                }
                for(int i=0;i<item.Count-1;i++)
                {
                    context.Carts!.Remove(item[i]);
                }
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return false;
            }
        }

        public async Task<List<Cart>> GetCartByUsername(string username)
        {
            try
            {
                var item = await context.Carts!.Where(x => x.Username == username).ToListAsync();
                if (item != null)
                {
                    return item;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return null;
            }
        }
    }
}
