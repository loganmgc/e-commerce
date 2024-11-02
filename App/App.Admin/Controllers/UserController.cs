using App.Admin.Models.ViewModels.User;
using App.Service.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class UserController : BaseController
    {
        public UserController(IServiceManager serviceManager, IMapper mapper) : base(serviceManager, mapper)
        {
        }

        [Route("/users")]
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var userList = await _serviceManager.UserService.GetAllUsersAsync();
            var viewModel = _mapper.Map<IEnumerable<UserListViewModel>>(userList);
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