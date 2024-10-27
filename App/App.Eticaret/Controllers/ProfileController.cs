using App.Eticaret.Models.ViewModels.Profile;
using App.Service.Models.UserDTOs;
using App.Service.Services.Interfaces;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Eticaret.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public ProfileController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [Route("/profile")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Details()
        {
            var userDto = await _serviceManager.UserService.GetUserByIdAsync(int.Parse(User.FindFirst(JwtClaimTypes.Id).Value));
            if (userDto is null)
            {
                return RedirectToAction("Index", "Home");
            }
            var userView = new ProfileDetailsViewModel
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                CreatedAt = userDto.CreatedAt
            };

            return View(userView);
        }

        [Route("/profile")]
        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] ProfileDetailsViewModel editMyProfileModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Details));
            }
            var user = new UpdateUserDto
            {
                UserId = int.Parse(User.FindFirst(JwtClaimTypes.Id).Value),
                FirstName = editMyProfileModel.FirstName,
                LastName = editMyProfileModel.LastName
            };
            await _serviceManager.UserService.UpdateUserAsync(user);
            return RedirectToAction(nameof(Details));
        }

        [Route("/my-orders")]
        [HttpGet]
        public IActionResult MyOrders()
        {
            return View();
        }

        [Route("/my-products")]
        [HttpGet]
        public IActionResult MyProducts()
        {
            return View();
        }
    }
}