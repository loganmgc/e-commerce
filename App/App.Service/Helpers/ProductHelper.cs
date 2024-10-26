using App.Data.Entities;
using App.Service.Models.ProductDTOs;

namespace App.Service.Helpers
{
    public class ProductHelper
    {
        public List<GetProductDto> ProductListing(IEnumerable<ProductEntity> products)
        {
            if (products is null)
            {
                return new List<GetProductDto>();
            }
            return products.Select(p => new GetProductDto
            {
                ProductId = p.ProductId,
                SellerName = $"{p.Seller.FirstName} {p.Seller.LastName}",
                CategoryId = p.CategoryId,
                CategoryName = p.Category.Name,
                Name = p.Name,
                Price = p.Price,
                Details = p.Details,
                StockAmount = p.StockAmount,
            }).ToList();
        }

    }
}
