using App.Admin.Models.ViewModels.Comment;
using App.Service.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class CommentController : BaseController
    {
        public CommentController(IServiceManager serviceManager, IMapper mapper) : base(serviceManager, mapper)
        {
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
            var viewModel = _mapper.Map<IEnumerable<CommentListViewModel>>(comments);

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