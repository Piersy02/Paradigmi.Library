using Paradigmi.Library.Application.Abstractions.Services;
using Paradigmi.Library.Models.Entities;
using Paradigmi.Library.Models.Repositories;
using Paradigmi.Library.Models.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Library.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public bool AddCategory(string name)
        {
            if (_categoryRepository.Get(name) != null)
                return false;
            Category category = new Category();
            category.Name = name;
            _categoryRepository.Add(category);
            _categoryRepository.SaveChanges();
            return true;
        }

        public bool DeleteCategory(string name)
        {
            Category category = _categoryRepository.Get(name);
            if (category != null && _categoryRepository.GetBooks(name).Count() == 0)
            {
                _categoryRepository.Delete(category.Name);
                _categoryRepository.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
