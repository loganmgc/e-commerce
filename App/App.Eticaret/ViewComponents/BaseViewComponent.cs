using App.Service.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.Eticaret.ViewComponents
{
    public abstract class BaseViewComponent : ViewComponent
    {
        protected readonly IServiceManager _serviceManager;
        protected readonly IMapper _mapper;

        protected BaseViewComponent(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }
    }
}
