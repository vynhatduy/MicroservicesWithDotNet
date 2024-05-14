using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductWebApi.Data;
using ProductWebApi.Model;
using ProductWebApi.Repository;

namespace ProductWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo repo;

        public ProductController(IProductRepo repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await repo.GetAllAsync());
        }
        [HttpGet("byCategoryId/{categoryId:int}")]
        public async Task<IActionResult> GetByCategoryId(int categoryId)
        {
            var result=await repo.GetByCateAsync(categoryId);
            if(result==null)
                return NotFound();
            return Ok(result);
        }
        [HttpGet("byName/{name}")]
        public async Task<IActionResult> GetByNameId(string name)
        {
            var result=await repo.GetByNameAsync(name);
            if(result==null)
                return NotFound();
            return Ok(result);
        }
        [HttpGet("byProductId/{productId:int}")]
        public async Task<IActionResult> GetByProductId(int productId)
        {
            var result=await repo.GetByIdAsync(productId);
            if(result==null)
                return NotFound();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductModel model)
        {
            var result=await repo.CreateAsync(model);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpPut("byProductId/{productId:int}")]
        public async Task<IActionResult> Update(int productId, ProductModel model)
        {
            var result=await repo.UpdateAsync(productId, model);
            if (!result)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpDelete("byProductId/{productId:int}")]
        public async Task<IActionResult> Delete(int productId)
        {
            var result=await repo.DeleteAsync(productId);
            if (!result)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}
