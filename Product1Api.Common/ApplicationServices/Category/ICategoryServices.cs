using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product1Api.Common.ApplicationServices.Category
{
    public interface ICategoryServices
    {
        public List<Category1> getcategory();
        Task createcategory([FromForm] CategoryDto categoryDto);
        Task updatecategory(int id, [FromForm] CategoryDto categoryDto);
        void deletecategory(int id);
        public Category1 idcategory(int id);
    }
}
