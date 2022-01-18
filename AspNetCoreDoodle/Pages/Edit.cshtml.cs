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

        [BindProperty]
        public Product Product { get; set; }
        public IEnumerable<SelectListItem> ProductCategories { get; set; }

        public EditModel(IProductData productData, IHtmlHelper htmlHelper)
        {
            _productData = productData;
            _htmlHelper = htmlHelper;
            ProductCategories = _htmlHelper.GetEnumSelectList<ProductCategory>();

        }
        public IActionResult OnGet(int? productId)
        {
            Product product;
            if (productId.HasValue)
            {
                product = _productData.GetProduct(productId.Value);
                if (product == null)
                {
                    return RedirectToPage("./NotFound");
                }
                Product = product;
               
            }
            else
            {
                Product = new Product();

            }

            return Page();

        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            if (Product.ProductId>0)
            {
                Product = _productData.Update(Product);
            }
            else
            {
                Product = _productData.Add(Product);
            }
            TempData["Message"] = "Product Saved!";
            return RedirectToPage("./ProductDetails", new { productId = Product.ProductId });
        }
    }
}
