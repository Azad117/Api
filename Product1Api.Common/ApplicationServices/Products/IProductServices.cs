using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.Models.Products;

namespace Product1Api.Common.ApplicationServices
{
    public interface IProductServices
        {
            List<Product1> getproducts();
            Task createproduct([FromForm]ProductDto productDto);
            Task updateproduct([FromForm]int id ,ProductDto productDto);
            void deleteproduct(int productId);
            Product1 idproduct(int productId);
        }

}