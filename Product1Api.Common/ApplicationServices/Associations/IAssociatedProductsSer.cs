using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.Models.Associations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product1Api.Common.ApplicationServices.Associations
{
    public interface IAssociatedProductsSer
    {
        List<AssociatedProducts1> getassociatedproducts();

        Task createassociatedproduct([FromForm] AssociatedProductsDto associatedProductsDto);
        Task updateassociatedproduct(int id, [FromForm] AssociatedProductsDto associatedProductsDto);
        void deleteassociatedproduct(int id);
        AssociatedProducts1 idassociatedproduct(int id);
    }
}
