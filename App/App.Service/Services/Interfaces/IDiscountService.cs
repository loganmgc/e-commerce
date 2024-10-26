using App.Service.Models.CategoryDTOs;
using App.Service.Models.DiscountDTOs;

namespace App.Service.Services.Interfaces
{
    public interface IDiscountService
    {
        Task<IEnumerable<GetDiscountDto>> GetDiscountsForCreateProductAsync();
    }
}
