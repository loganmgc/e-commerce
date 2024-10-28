using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using App.Admin.Models.ViewModels;
using App.Service.Models.UserDTOs;
using App.Service.Services.Interfaces;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace App.Admin.Controllers
{
    public class AuthController : Controller
    {
        private readonly IServiceManager _serviceManager;
        private readonly IConfiguration _config;

        public AuthController(IServiceManager serviceManager, IConfiguration config)
        {
            _serviceManager = serviceManager;
            _config = config;
        }

        [Route("/login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [Route("/login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginViewModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var loginDto = new LoginUserDto
            {
                Email = loginModel.Email,
                Password = loginModel.Password,
            };
            var user = await _serviceManager.UserService.LoginUserAsync(loginDto);
            if (user is null || user.RoleName != "admin")
            {
                ViewBag.Error = "Email or password incorrect";
                return View();
            }
            var claims = new List<Claim>
            {
                new Claim(JwtClaimTypes.Id, user.UserId.ToString()),
                new Claim(JwtClaimTypes.Role, user.RoleName),
                new Claim(JwtClaimTypes.Name, user.FirstName)
            };

            var symmetrickey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Secret"]));

            var tokenOptions = new JwtSecurityToken(
                issuer: "Admin",
                audience: "Admin",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: new SigningCredentials(symmetrickey, SecurityAlgorithms.HmacSha256)
                );

            string tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            Response.Cookies.Append("user_token", tokenString, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict
            });

            return RedirectToAction("Index", "Home"); ;
        }

        [Authorize]
        [Route("/logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("user_token");
            return RedirectToAction(nameof(Login));
        }
    }
}