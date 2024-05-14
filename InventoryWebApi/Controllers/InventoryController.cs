using InventoryWebApi.Model;
using InventoryWebApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace InventoryWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        public IProductRepo repo;
        public InventoryController(IProductRepo repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await repo.GetAllAsync());
        }
        [HttpGet("byId/{productId}")]
        public async Task<IActionResult> GetById(int productId)
        {
            var result=await repo.GetByIdAsync(productId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("byName/{productName}")]
        public async Task<IActionResult> GetByName(string productName)
        {
            var result=await repo.GetByNameAsync(productName);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("byNum/{soluong}")]
        public async Task<IActionResult> GetByNum(int soluong)
        {
            var result=await repo.GetByNumAsync(soluong);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductModel model)
        {
            var result=await repo.CreateAsync(model);
            if (!result)
            {
                return BadRequest(result);
            }
           
            return Ok(result);
        }
        [HttpPut("byId/{productId}")]
        public async Task<IActionResult> Update(int productId,ProductModel model)
        {
            var result=await repo.UpdateAsync(productId,model);
            if (!result)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpDelete("byId/{productId}")]
        public async Task<IActionResult> Delete(int productId)
        {
            var result=await repo.Delete(productId);
            if (!result)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
