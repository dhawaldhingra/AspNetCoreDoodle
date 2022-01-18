namespace AspNetCoreDoodle.Data
{
    public class ProductData : IProductData
    {
        private IList<Product> products;
        private int maxId = 4;
        public ProductData()
        {
            products = new List<Product>()
            {
                new Product(){Price = 20, ProductId = 1, ProductName = "Pen", Category=ProductCategory.Stationary },
                new Product(){Price = 30, ProductId = 2, ProductName = "USB Cable", Category = ProductCategory.Electronics },
                new Product(){Price = 40, ProductId = 3, ProductName = "USB Hub", Category = ProductCategory.Electronics },
                new Product(){Price = 50, ProductId = 4, ProductName = "Table", Category = ProductCategory.Household }
            };
        }

        public Product Add(Product product)
        {
            if(product!=null)
            {
                product.ProductId = ++maxId;
            }
            products.Add(product);
            return product;
        }

        public Product GetProduct(int id)
        {
            return products.Where(p=>p.ProductId == id).FirstOrDefault();
        }

        public IEnumerable<Product> GetProducts(string searchTerm)
        {
            if(string.IsNullOrEmpty(searchTerm))
            {
                return products;
            }
            else
            {
                return products.Where(p=>p.ProductName.Contains(searchTerm));  
            }
        }

        public IEnumerable<Product> GetProducts()
        {
            return products;
        }

        public Product Update(Product updatedProduct)
        {
            var product = products.Where(p=>p.ProductId==updatedProduct.ProductId).FirstOrDefault();    
            if(product!=null)
            {
                product.Price = updatedProduct.Price;  
                product.ProductName = updatedProduct.ProductName;
                product.Category = updatedProduct.Category;
            }

            return product;
        }
    }
}
