using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.ApplicationServices.Associations;
using Product1Api.Common.Models.Associations;
using Product1Api.Common.Models.Attributes;
using Product1Api.Common.Repository.Associations;
using Product1Api.Common.Repository.Attributes;
using Product1Api.Repositories.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product1Api.ApplicationServices.ApplicationServices.Associations
{
    public class AssociatedProductsSer : IAssociatedProductsSer
    {
        private readonly IAssociatedProductsRep _associatedProductsRep;

        public AssociatedProductsSer(IAssociatedProductsRep associatedProductsRep)
        {
            _associatedProductsRep = associatedProductsRep;
        }
        public List<AssociatedProducts1> getassociatedproducts()
        {
            return _associatedProductsRep.GetAssociatedProducts();
        }
        public async Task createassociatedproduct([FromForm] AssociatedProductsDto associatedProductsDto)
        {
             _associatedProductsRep.CreateAssociatedProducts(associatedProductsDto);
        }
        public async Task updateassociatedproduct(int id, [FromForm] AssociatedProductsDto associatedProductsDto)
        {
             _associatedProductsRep.UpdateAssociatedProducts(id, associatedProductsDto);

        }
        public void deleteassociatedproduct(int id)
        {
            _associatedProductsRep.DeleteAssociatedProducts(id);
        }
        public AssociatedProducts1 idassociatedproduct(int id)
        {
            return _associatedProductsRep.IdAssociatedProducts(id);
        }
    }
}
