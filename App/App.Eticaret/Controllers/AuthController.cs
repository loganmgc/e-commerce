using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using App.Eticaret.Models.ViewModels.Auth;
using App.Service.Models.UserDTOs;
using App.Service.Services.Interfaces;
using AutoMapper;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace App.Eticaret.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config, IServiceManager serviceManager, IMapper mapper) : base(serviceManager, mapper)
        {
            _config = config;
        }

        [Route("/register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [Route("/register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserViewModel newUser)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var isUnique = await _serviceManager.UserService.CheckEmailExistsAsync(newUser.Email);
            if (!isUnique)
            {
                ModelState.AddModelError("Email", "This email address is used by another user");
                return View();
            }
            var user = _mapper.Map<AddUserDto>(newUser);
            await _serviceManager.UserService.AddUserAsync(user);
            TempData["SuccessMessage"] = "You have been successfully registered";
            return View();
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
            var loginDto = _mapper.Map<LoginUserDto>(loginModel);
            var user = await _serviceManager.UserService.LoginUserAsync(loginDto);
            if (user is null)
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
                issuer: "ETicaret",
                audience: "ETicaret",
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
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

        [Route("/forgot-password")]
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [Route("/forgot-password")]
        [HttpPost]
        public IActionResult ForgotPassword([FromForm] object forgotPasswordMailModel)
        {
            return View();
        }

        [Route("/renew-password/{verificationCode}")]
        [HttpGet]
        public IActionResult RenewPassword([FromRoute] string verificationCode)
        {
            return View();
        }

        [Route("/renew-password")]
        [HttpPost]
        public IActionResult RenewPassword([FromForm] RenewPasswordViewModel newPassword)
        {
            //    if (!ModelState.IsValid)
            //    {
            //        return View();
            //    }
            //    var userId = int.Parse(User.FindFirst(JwtClaimTypes.Id).Value);
            //    var password = new RenewPasswordDto
            //    {
            //        UserId = userId,
            //        OldPassword = newPassword.OldPassword,
            //        NewPassword = newPassword.NewPassword,
            //    };
            //    if(!await _serviceManager.UserService.RenewPassword(password))
            //    {
            //        ModelState.AddModelError("OldPassword", "Password incorrectly entered");
            //        return View();
            //    }
            //    TempData["SuccessMessage"] = "Password has been successfully changed";
            return View();
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