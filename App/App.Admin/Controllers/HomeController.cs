using App.Service.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class HomeController : BaseController
    {
        public HomeController(IServiceManager serviceManager, IMapper mapper) : base(serviceManager, mapper)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}