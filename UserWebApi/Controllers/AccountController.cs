using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserWebApi.Data;
using UserWebApi.Helper;
using UserWebApi.Model;
using UserWebApi.Repository;

namespace UserWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserRoleRepo repo;
        private readonly UserContext context;

        public AccountController(IUserRoleRepo repo,UserContext context)
        {
            this.repo = repo;
            this.context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await repo.GetAllAsync());
        }
        [HttpGet("byUserId/{userId:int}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var result = await repo.GetByUserIdAsync(userId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("byUserName/{username}")]
        public async Task<IActionResult> GetUserById(string username)
        {
            var result = await repo.GetByUsername(username);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserRoleModel model)
        {
            var result = await repo.CreateAsync(model);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPut("byUserId/{userId}")]
        public async Task<IActionResult> Update(int userId, UserRoleModel model, int roleId)
        {
            var result = await repo.UpdateAsync(userId, model,roleId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpDelete("byUserId/{userId}")]
        public async Task<IActionResult> Delete(int userId)
        {
            var result = await repo.DeleteAsync(userId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // login
        [HttpPost("login/{username}")]
        public async Task<IActionResult> Login(string username,string password)
        {
            try
            {
                var item = await context.UserRoles!.FirstOrDefaultAsync(x => x.Usename.Equals(username));
                if (item == null)
                {
                    return NotFound();
                }
                var passhasher = HasherPassword.CheckHashPass(password.ToString().Trim(), item.Salt);
                if (string.IsNullOrEmpty(passhasher))
                {
                    return BadRequest();
                }
                if (!item.Password.ToString().Trim().Equals(passhasher.ToString().Trim()))
                {
                    return Unauthorized("Tài khoản hoặc mật khẩu không đúng");
                }
                var userInfo = await context.Users!.FirstOrDefaultAsync(x => x.Id == item.UserId);
                var roleInfo = await context.Roles!.FirstOrDefaultAsync(x => x.Id == item.RoleId);
                if (userInfo == null || roleInfo == null)
                {
                    return NotFound("Không tìm thấy thông tin người dùng");
                }
                var userData = new UserRespone
                {
                    UserName = userInfo.SDT.ToString().Trim(),
                    Role = roleInfo.Ten.ToString().Trim()
                };
                return Ok(userData);
            }
            catch(Exception e)
            {
                Console.Out.WriteLineAsync(e.ToString());
                return BadRequest();
            }
        }
     }
}
