using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductWebApi.Data;
using ProductWebApi.Model;

namespace ProductWebApi.Repository
{
    public class ProductRepo : IProductRepo
    {
        public readonly ProductContext _context;
        private readonly IMapper _mapper;

        public ProductRepo(ProductContext context,IMapper mapper)
        {
            this._context=context; 
            this._mapper=mapper;
        }
        public async Task<bool> CreateAsync(ProductModel model)
        {
            try
            {
                await _context.Products.AddAsync(_mapper.Map<Product>(model));
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
                var item = await _context.Products!.FirstOrDefaultAsync(x => x.ID == id);
                if (item == null)
                {
                    return false;
                }
                _context.Products!.Remove(item);
                await _context.SaveChangesAsync();
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
            return await _context.Products!.ToListAsync();
        }

        public async Task<List<Product>> GetByCateAsync(int cateId)
        {
            try
            {
                var ds = await _context.Products!.Where(x => x.categoryId == cateId).ToListAsync();
                return ds;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            try
            {
                var item = await _context.Products!.FirstOrDefaultAsync(x => x.ID == id);
                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public async Task<List<Product>> GetByNameAsync(string name)
        {
            try
            {
                var ds = await _context.Products!.Where(x => x.Ten.Contains( name)).ToListAsync();
                return ds;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public async Task<bool> UpdateAsync(int id, ProductModel model)
        {
            try
            {
                var item=await _context.Products!.FirstOrDefaultAsync(x=>x.ID == id);
                if(item==null)
                { return false; }
                item.Ten=model.Ten;
                item.MoTa = model.MoTa;
                item.Url=model.Url;
                item.ThanhPhan = model.ThanhPhan;
                item.CongDung=model.CongDung;
                item.CachDung = model.CachDung;
                item.categoryId = model.categoryId;
                item.Gia=model.Gia;
                _context.Products!.Update(item);
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
