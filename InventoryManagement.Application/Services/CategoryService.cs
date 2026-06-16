using AutoMapper;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Application.Interfaces;
using InventoryManagement.Domain.Entities;
using System.Collections.Generic;

namespace InventoryManagement.Application.Services
{
    public class CategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void AddCategory(CreateCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            _repository.Add(category);
        }

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            return _mapper.Map<IEnumerable<CategoryDto>>(_repository.GetAll());
        }

        public void UpdateCategory(int id, UpdateCategoryDto dto)
        {
            var category = _repository.GetById(id);
            if (category != null)
            {
                category.Name = dto.Name;
                category.Description = dto.Description;
                _repository.Update(category);
            }
        }

        public void DeleteCategory(int id)
        {
            var category = _repository.GetById(id);
            if (category != null)
            {
                _repository.Delete(category);
            }
        }
    }
}
