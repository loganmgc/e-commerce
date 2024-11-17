using App.Eticaret.Models.ViewModels.Order;
using App.Service.Models.OrderDTOs;
using App.Service.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Eticaret.Controllers
{
    public class OrderController : BaseController
    {
        public OrderController(IServiceManager serviceManager, IMapper mapper) : base(serviceManager, mapper)
        {
        }

        [Authorize(Roles = "buyer, seller")]
        [Route("/order")]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CheckoutViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit", "Cart");
            }
            model.UserId = GetUserId().Value;
            string orderCode = await _serviceManager.OrderService.CreateOrder(_mapper.Map<AddOrderDto>(model));
            return RedirectToAction(nameof(Details), new { OrderCode = orderCode });
        }

        [Authorize(Roles = "buyer, seller")]
        [Route("/order/{orderCode}/details")]
        [HttpGet]
        public async Task<IActionResult> Details([FromRoute] string orderCode)
        {
            var orderDto = await _serviceManager.OrderService.GetOrderDetailsAsync(orderCode);
            var orderViewModel = _mapper.Map<OrderDetailsViewModel>(orderDto);
            return View(orderViewModel);
        }
    }
}