using AutoMapper;
using InventoryWebApi.Data;
using InventoryWebApi.Model;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace InventoryWebApi.Repository
{
    public class ProductRepo : IProductRepo
    {
        private readonly ProductContext context;
        private readonly IMapper mapper;

        public ProductRepo(ProductContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper=mapper;
        } 
        public async Task<bool> CreateAsync(ProductModel model)
        {
            try
            {
                await context.Products.AddAsync(mapper.Map<Product>(model));
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var item = await context.Products!.FirstOrDefaultAsync(x => x.Id == id);
                if (item == null)
                {
                    return false;
                }
                context.Products!.Remove(item);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await context.Products!.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await context.Products!.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Product>> GetByNameAsync(string name)
        {
            return await context.Products!.Where(x=>x.Ten.Contains(name)).ToListAsync();
        }

        public async Task<List<Product>> GetByNumAsync(int num)
        {
            return await context.Products!.Where(x => x.SoLuong==num).ToListAsync();
        }

        public async Task<bool> UpdateAsync(int id, ProductModel model)
        {
            try
            {
                var item = await context.Products!.FirstOrDefaultAsync(x => x.Id == id);
                if (item == null)
                {
                    return false;
                }
                item.Ten=model.Ten;
                item.SoLuong=model.SoLuong; 
                context.Products!.Update(item);
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
