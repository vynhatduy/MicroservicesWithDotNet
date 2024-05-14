using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderWebApi.Data;
using OrderWebApi.Model;
using OrderWebApi.Repository;

namespace OrderWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepo repo;

        public OrderController(IOrderRepo repo)
        {
            this.repo=repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await repo.GetAllAsync());
        }
        [HttpGet("byUserId/{userId:int}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var result=await repo.GetByUserIdAsync(userId);
            if (result == null)
            {
                return NotFound();  
            }
            return Ok(result);
        }
        [HttpGet("byOrderId/{orderId:int}")]
        public async Task<IActionResult> GetByOrderId(int orderId)
        {
            var result = await repo.GetByIdAsync(orderId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("byCreateDate/{ngay:datetime}")]
        public async Task<IActionResult> GetByCreateDate(DateTime ngay)
        {
            var result = await repo.GetByCreateDateAsync(ngay);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult>Create(OrderModel model)
        {
            var result = await repo.CreateAsync(model);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpPut("byOrderId/{orderId:int}")]
        public async Task<IActionResult>Update(int orderId,OrderModel model)
        {
            var result = await repo.UpdateAsync(orderId,model);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpDelete("byOrderId/{orderId:int}")]
        public async Task<IActionResult>Delete(int orderId)
        {
            var result = await repo.DeleteAsync(orderId);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
