using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using AuthenticationWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration config;
        private readonly HttpClient _userWebApi;

        public AuthenticationController(IConfiguration config, IHttpClientFactory factory)
        {
            this.config = config;
            _userWebApi = factory.CreateClient();
            _userWebApi.BaseAddress = new System.Uri("https://localhost:8001/api/");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            try
            {
                if (model.Username == "admin" && model.Password == "admin"||model.Username=="user"&&model.Password=="user")
                {
                    var tokenString = GenerateJWTToken(model.Username, "Administrator");
                    if (string.IsNullOrEmpty(tokenString))
                    {
                        return Unauthorized("Không thể tạo chuỗi xác thực người dùng");
                    }
                    return Ok(new { token = tokenString });
                }
                var response = await _userWebApi.PostAsync($"Account/login={model.Username}", new FormUrlEncodedContent(new[]
                {
            new KeyValuePair<string,string>("password", model.Password),
        }));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var userData = JsonSerializer.Deserialize<UserRespone>(content);
                    var tokenString = GenerateJWTToken(userData.UserName, userData.Role);
                    if (string.IsNullOrEmpty(tokenString))
                    {
                        return Unauthorized("Không thể tạo chuỗi xác thực người dùng");
                    }
                    return Ok(new { token = tokenString });
                }
                else
                {
                    return Unauthorized("Tài khoản hoặc mật khẩu không đúng");
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return BadRequest();
            }
        }

        private string GenerateJWTToken(string userName, string role)
        {
            try
            {
                var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config["Jwt:Secret"]));
                var cendentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(config["Jwt:Issuer"],
                    config["Jwt:Issuer"],
                    new Claim[]
                    {
                    new Claim(ClaimTypes.Name,userName),
                    new Claim(ClaimTypes.Role,role)
                    },
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: cendentials);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

    }
}
