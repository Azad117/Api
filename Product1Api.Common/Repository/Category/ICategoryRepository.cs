using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Product1Api.Common.Models.Category;

namespace Product1Api.Common.Repository.Category
{
    public interface ICategoryRepository
    {
        public List<Category1> GetCategory();

        Task CreateCategory([FromForm] CategoryDto categoryDto);

        Task UpdateCategory(int id, [FromForm] CategoryDto categoryDto);

        void DeleteCategory(int id);
        public Category1 IdCategory(int id);
    }
}
