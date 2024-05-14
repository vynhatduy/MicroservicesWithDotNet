using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductWebApi.Model;
using ProductWebApi.Repository;

namespace ProductWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepo repo;

        public CategoryController(ICategoryRepo repo)
        {
            this.repo=repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await repo.GetAllAsync());
        }
        [HttpGet("{categoryId:int}")]
        public async Task<IActionResult> GetById(int categoryId)
        {
            var result =await repo.GetByIdAsync(categoryId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryModel model)
        {
            var result=await repo.CreateAsync(model);
            if(!result)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpPut("{categoryId:int}")]
        public async Task<IActionResult> Update(int categoryId, CategoryModel model)
        {
            var result = await repo.UpdateAsync(categoryId,model);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpDelete("{categoryId:int}")]
        public async Task<IActionResult> Delete(int categoryId)
        {
            var result = await repo.DeleteAsync(categoryId);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
