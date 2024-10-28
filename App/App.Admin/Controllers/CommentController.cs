using App.Admin.Models.ViewModels.Comment;
using App.Service.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class CommentController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public CommentController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [Route("/comment")]
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var comments = await _serviceManager.ProductCommentService.GetAllUnapprovedCommentsAsync();
            if (comments is null)
            {
                ViewBag.Error = "No comments pending for approval";
                return View();
            }
            var viewModel = comments.Select(c => new CommentListViewModel
            {
                ProductCommentId = c.ProductCommentId,
                ProductId = c.ProductId,
                ProductName = c.ProductName,
                UserId = c.UserId, 
                UserName = c.UserName,
                Text = c.Text,
                StarCount = c.StarCount,
                CreatedAt = c.CreatedAt
            }).ToList();

            return View(viewModel);
        }

        [Route("/comment/{commentId:int}/approve")]
        [HttpGet]
        public async Task<IActionResult> Approve([FromRoute] int commentId)
        {
            var result = await _serviceManager.ProductCommentService.ApproveCommentAsync(commentId);
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