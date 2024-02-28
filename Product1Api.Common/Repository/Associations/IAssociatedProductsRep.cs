using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.Models.Associations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product1Api.Common.Repository.Associations
{
    public interface IAssociatedProductsRep
    {
        List<AssociatedProducts1> GetAssociatedProducts();
        Task CreateAssociatedProducts([FromForm]AssociatedProductsDto associatedProductsDto);
        Task UpdateAssociatedProducts(int id, [FromForm]AssociatedProductsDto associatedProductsDto);
        void DeleteAssociatedProducts(int id);
        AssociatedProducts1 IdAssociatedProducts(int id);
    }
}
