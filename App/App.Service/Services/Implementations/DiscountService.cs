using App.Data.Repositories.Interfaces;
using App.Service.Models.DiscountDTOs;
using App.Service.Services.Interfaces;
using AutoMapper;

namespace App.Service.Services.Implementations
{
    public class DiscountService : ServiceBase, IDiscountService
    {
        public DiscountService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public async Task<IEnumerable<GetDiscountDto>> GetDiscountsForCreateProductAsync()
        {
            var discounts = await _repositoryManager.IDiscountRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetDiscountDto>>(discounts);
        }
    }
}
