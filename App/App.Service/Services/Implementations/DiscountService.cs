using App.Data.Repositories.Interfaces;
using App.Service.Models.DiscountDTOs;
using App.Service.Services.Interfaces;

namespace App.Service.Services.Implementations
{
    public class DiscountService : IDiscountService
    {
        private readonly IRepositoryManager _repositoryManager;

        public DiscountService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<IEnumerable<GetDiscountDto>> GetDiscountsForCreateProductAsync()
        {
            var discounts = await _repositoryManager.IDiscountRepository.GetAllAsync();
            return discounts.Select(x => new GetDiscountDto
            {
                DiscountId = x.DiscountId,
                DiscountRate = x.DiscountRate,
            }).ToList();
        }
    }
}
