using System.Security.Claims;
using App.Service.Services.Interfaces;
using AutoMapper;
using IdentityModel;
using Microsoft.AspNetCore.Mvc;

namespace App.Eticaret.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly IServiceManager _serviceManager;
        protected readonly IMapper _mapper;

        protected BaseController(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }
        protected int? GetUserId() => int.TryParse(User.FindFirstValue(JwtClaimTypes.Id), out int userId) ? userId : null;
    }
}
