using Product1Api.Common.ApplicationServices;
using Product1Api.Common.Repository;
using Product1Api.Common.Models.Products;


namespace Product1Api.ApplicationServices.ApplicationServices.Products
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productrepository;
        public ProductServices(IProductRepository productrepository)
        {
            _productrepository = productrepository;
        }
        public static List<Product1> products = new List<Product1>();
        public  List<Product1> getproducts()
        {
            return _productrepository.GetProducts();
        }
        //postMethod
        public async Task createproduct(ProductDto productDto)
        {
            _productrepository.CreateProduct(productDto);
        }
        //putmethod
        public async Task updateproduct(int id, ProductDto productDto)
        {
            _productrepository.UpdateProduct(id, productDto);
        }
        //deletemethod
        public void deleteproduct(int productId)
        {
            _productrepository.DeleteProduct(productId);
        }
        public Product1 idproduct(int productId)
        {
            return _productrepository.IdProduct(productId);
        }
    }
}