using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductWebApi.Data;
using ProductWebApi.Model;

namespace ProductWebApi.Repository
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly ProductContext context;
        private readonly IMapper mapper;

        public CategoryRepo(ProductContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<bool> CreateAsync(CategoryModel model)
        {
            try
            {
                await context.Categories.AddAsync(mapper.Map<Category>(model));
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
                var item = await context.Categories!.FirstOrDefaultAsync(x => x.Id == id);
                if (item != null)
                {
                    return false;
                }
                context.Categories!.Remove(item);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await context.Categories!.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await context.Categories!.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<bool> UpdateAsync(int id, CategoryModel model)
        {
            try
            {
                var item= await context.Categories!.FirstOrDefaultAsync(x => x.Id == id);
                if (item == null)
                {
                    return false;
                }
                item.Ten=model.Ten;
                item.MoTa = model.MoTa;
                context.Categories!.Update(item);
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
