using App.Data.Repositories.Interfaces;
using AutoMapper;

namespace App.Service.Services.Implementations
{
    public class ServiceBase
    {
        protected readonly IRepositoryManager _repositoryManager;
        protected readonly IMapper _mapper;

        public ServiceBase(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
    }
}
