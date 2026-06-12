using System.Collections.Generic;
using AutoMapper;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Application.Interfaces;
using InventoryManagement.Domain.Entities;

namespace InventoryManagement.Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //for create
        public void AddProduct(CreateProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _repository.Add(product);
        }

        //for search 
        public IEnumerable<ProductDto> SearchProducts(string name)
        {
            var products = _repository.Search(name);
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        //get by id 
        public ProductDto GetProductById(int id)
        {
            var product = _repository.GetById(id);
            return _mapper.Map<ProductDto>(product);
        }

        //for update
        public void UpdateProduct(int id, CreateProductDto productDto)
        {
            var product = _repository.GetById(id);
            if (product != null)
            {
                 
                _mapper.Map(productDto, product);
                _repository.Update(product);
            }
        }

        //delete 
        public void DeleteProduct(int id)
        {
            var product = _repository.GetById(id);
            if (product != null)
            {
                _repository.Delete(product);
            }
        }
    }
}