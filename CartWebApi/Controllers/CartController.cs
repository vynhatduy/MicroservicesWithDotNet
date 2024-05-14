using CartWebApi.Data;
using CartWebApi.Reponsitory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CartWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepo repo;

        public CartController(ICartRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> Get(string username)
        {
            var respone = await repo.GetCartByUsername(username);
            if (respone != null)
            {
                return Ok(respone);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Cart model)
        {
            var respone = await repo.Create(model);
            if (!respone)
            {
                return BadRequest();
            }
            return Ok(respone);
        }
        [HttpDelete("{username}/{productId}")]
        public async Task<IActionResult> DeleteById(string username, int productId)
        {
            var respone = await repo.DeleteByProductId(username, productId);
            if (!respone)
            {
                return BadRequest();
            }
            return Ok(respone);
        }
        [HttpDelete("{username}")]
        public async Task<IActionResult> DeleteByUsername(string username)
        {
            var respone=await repo.DeleteByUsername(username);
            if (!respone)
            {
                return BadRequest();
            }
            return Ok(respone);
        }

    }
}
