using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SampleInterface;

namespace API.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginEntity _login;
        private readonly IConfiguration _config;
        public LoginController(ILoginEntity login, IConfiguration config)
        {
            _login = login;
            _config = config;
        }
        [HttpGet]
        [Route("SignUp")]
        public IActionResult SignUp()
        {
            try
            {
                UserModel login = new UserModel();
                //string connectionString = _config.GetSection("ConnectionStrings").GetSection("Database").Value;
                IActionResult response = Unauthorized();
                login.EmailAddress = "jibin8086@gmail.com";
                login.Passwd = "123";
                var user = _login.AuthenticateUser(login);

                if (user != null)
                {
                    var tokenString = GenerateJSONWebToken(login);
                    login.Token = tokenString.ToString();
                    return Ok(new Envelope<UserModel>(true, "data-fetch-success", login));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        [HttpGet]
        [Route("getdata")]
        [Authorize]
        public  IActionResult GetData()
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type.Equals("userId", StringComparison.InvariantCultureIgnoreCase));
            if (userId != null)
            {
                return Ok($"This is your Id: {userId.Value}");
            }
            return BadRequest("No claim");
        }

        private string GenerateJSONWebToken(UserModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>();
            claims.Add(new Claim("userId", Convert.ToString(userInfo.ID)));

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [HttpPost]
        [Route("fileUplaod")]
        public async Task<IActionResult> OnPostUploadAsync(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);
            var filePath = string.Empty;
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                      filePath = Path.GetTempFileName();

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            try
            {
                System.IO.File.Move(filePath, "C:\\Users\\jibin.jh\\Downloads\\New folder\\Test7");
            }
            catch (Exception ex)
            {

                throw;
            }
            

            return Ok(new { count = files.Count, size, filePath });
        }
        [Route("get_image")]
        [HttpGet]
        public IActionResult Get()
        {
            Byte[] b = System.IO.File.ReadAllBytes(@"C:\\Users\\jibin.jh\\Downloads\\New folder\\Test1");          
            return File(b, "image/jpeg");
        }
      
    }
}