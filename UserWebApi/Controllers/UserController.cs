using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserWebApi.Data;
using UserWebApi.Model;
using UserWebApi.Repository;

namespace UserWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo userRepo;

        public UserController(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
                return Ok(await userRepo.GetAllAsync());
        }
        [HttpGet("byUserId/{userId:int}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var result = await userRepo.GetByIdAsync(userId);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("byPhoneNum/{phoneNum}")]
        public async Task<IActionResult> GetUserById(string phoneNum)
        {
            if (phoneNum.Length!=10)
            {
                return BadRequest();
            }
            var result = await userRepo.GetByPhoneNumAsync(phoneNum);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserModel user)
        {
            var result = await userRepo.CreateAsync(user);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPut("byUserId/{userId:int}")]
        public async Task<IActionResult> Update(int userId,UserModel user)
        {
            var result = await userRepo.UpdateAsync(userId,user);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpDelete("byUserId/{userId:int}")]
        public async Task<IActionResult> Delete(int userId)
        {
            var result = await userRepo.DeleteAsync(userId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
