using App.Admin.Models.ViewModels.User;
using App.Service.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class UserController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public UserController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [Route("/users")]
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var userList = await _serviceManager.UserService.GetAllUsersAsync();
            var viewModel = userList.Select(u => new UserListViewModel
            {
                UserId = u.UserId,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                CreatedAt = DateTime.Now,
                RoleName = u.RoleName,
            }).ToList();
            return View(viewModel);
        }

        [Route("/users/{userId:int}/approve")]
        [HttpGet]
        public async Task<IActionResult> Approve([FromRoute] int userId)
        {
            var result = await _serviceManager.UserService.ApproveSellerAsync(userId);
            if (!result)
            {
                TempData["ErrorMessage"] = "Failed to approve";
            }
            else
            {
                TempData["SuccessMessage"] = "Successfully approved";
            }
            return RedirectToAction(nameof(List));
        }
    }
}