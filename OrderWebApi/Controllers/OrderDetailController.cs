using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderWebApi.Model;
using OrderWebApi.Repository;

namespace OrderWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailRepo repo;

        public OrderDetailController(IOrderDetailRepo repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await repo.GetAllAsync());
        }
        [HttpGet("byOrderId/{orderId:int}")]
        public async Task<IActionResult> GetByOrderId(int orderId)
        {
            var result = await repo.GetByOrderIdAsync(orderId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("byProductId/{productId:int}")]
        public async Task<IActionResult> GetByProductId(int productId)
        {
            var result = await repo.GetByProductIdAsync(productId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(OrderDetailModel model)
        {
            var result = await repo.CreateAsync(model);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpPut("byOrderId/{orderId:int}")]
        public async Task<IActionResult> Update(int orderId, OrderDetailModel model)
        {
            var result = await repo.UpdateAsync(orderId, model);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpDelete("byOrderId/{orderId:int}")]
        public async Task<IActionResult> Delete(int orderId)
        {
            var result = await repo.DeleteAsync(orderId);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpDelete("byProductId/{productId:int}")]
        public async Task<IActionResult> DeleteProductId(int productId)
        {
            var result = await repo.DeleteItemProductAsync(productId);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}