using App.Eticaret.Models.ViewModels.ProductComment;
using App.Service.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.Eticaret.ViewComponents
{
    public class ProductCommentViewComponent : BaseViewComponent
    {
        public ProductCommentViewComponent(IServiceManager serviceManager, IMapper mapper) : base(serviceManager, mapper)
        {
        }
        public async Task<IViewComponentResult> InvokeAsync(int productId)
        {
            var comments = await _serviceManager.ProductCommentService.GetAllCommentsByProductIdAsync(productId);
            var commentsViewModel =  _mapper.Map<IEnumerable<GetProductCommentViewModel>>(comments).ToArray();
            var viewModel = new ProductCommentsViewModel
            {
                ProductId = productId,
                Comments = commentsViewModel,
                NewComment = new AddProductCommentViewModel()
            };

            return View(viewModel);
        }
    }
}
