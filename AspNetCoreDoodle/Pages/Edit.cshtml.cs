using AspNetCoreDoodle.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetCoreDoodle.Pages
{
    public class EditModel : PageModel
    {
        private readonly IProductData _productData;
        private readonly IHtmlHelper _htmlHelper;

        public Product Product { get; set; }
        public IEnumerable<SelectListItem> ProductCategories { get; set; }

        public EditModel(IProductData productData, IHtmlHelper htmlHelper)
        {
            _productData = productData;
            _htmlHelper = htmlHelper;
            
        }
        public IActionResult OnGet(int productId)
        {
            ProductCategories = _htmlHelper.GetEnumSelectList<ProductCategory>();
            var product = _productData.GetProduct(productId);
            if(product == null)
            {
                return RedirectToPage("./NotFound");
            }
            Product = product;
            return Page();
        }
    }
}
