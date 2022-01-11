using AspNetCoreDoodle.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreDoodle.Pages
{
    public class DhawalModel : PageModel
    {
        public string PageTitle { get; private set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        internal IEnumerable<Product> products;
        private IProductData _productData;

        public DhawalModel(IProductData productData)
        {
            _productData = productData;
        }
        public void OnGet()
        {
            PageTitle = "My ASP.NET CORE Page";
            products = _productData.GetProducts();
            products = _productData.GetProducts(SearchTerm);
        }
    }
}
