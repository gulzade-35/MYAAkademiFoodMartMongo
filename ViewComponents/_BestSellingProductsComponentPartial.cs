using FoodMartMongo.Dtos.ProductDtos;
using FoodMartMongo.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace FoodMartMongo.ViewComponents
{
    public class _BestSellingProductsComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _BestSellingProductsComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.GetAllProductsAsync();
            if (values == null)
            {
                values = new List<ResultProductDto>();
            }
            var bestSellingProducts = values
                .OrderBy(p => p.Price)
                .Take(6)
                .ToList();

            return View(bestSellingProducts);
        }
    }
}
