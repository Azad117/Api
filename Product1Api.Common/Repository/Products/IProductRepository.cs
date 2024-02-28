using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.Models.Products;

namespace Product1Api.Common.Repository
{
    public interface IProductRepository
        {
            List<Product1> GetProducts();
            Task CreateProduct([FromForm] ProductDto productDto);
            Task UpdateProduct([FromForm] int id,ProductDto productDto);
            void DeleteProduct(int id);
            Product1 IdProduct(int id);
        }

}