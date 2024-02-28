using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.ApplicationServices.Category;
using Product1Api.Common.Models.Category;
using Product1Api.Common.Repository.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product1Api.ApplicationServices.ApplicationServices.Category
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryServices(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<Category1> getcategory()
        {
            return _categoryRepository.GetCategory();
        }
        public async Task createcategory([FromForm] CategoryDto categoryDto)
        {
            _categoryRepository.CreateCategory(categoryDto);
        }
        public async Task updatecategory(int id, [FromForm] CategoryDto categoryDto)
        {
            _categoryRepository.UpdateCategory(id, categoryDto);
        }
        public void deletecategory(int id)
        {
            _categoryRepository.DeleteCategory(id);
        }
        public Category1 idcategory(int id)
        {
            return _categoryRepository.IdCategory(id);
        }
    }
}
