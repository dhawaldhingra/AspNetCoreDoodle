using AspNetCoreDoodle.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreDoodle.Pages
{
    public class ProductDetailsModel : PageModel
    {
        private readonly IProductData _productData;
        [TempData]
        public string Message { get; set; }

        public Product Product { get; set; }
        public ProductDetailsModel(IProductData productData)
        {
            _productData = productData;
        }
        public IActionResult OnGet(int productId)
        {
            Product = _productData.GetProduct(productId);
            if (Product == null)
                return RedirectToPage("./NotFound");
            else
                return Page();

        }
    }
}
