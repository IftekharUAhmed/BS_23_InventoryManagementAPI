using InventoryManagement.Application.DTOs;
using InventoryManagement.Application.Interfaces;
using InventoryManagement.Domain.Entities;
using System.Collections.Generic;

namespace InventoryManagement.Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public List<ProductDto> GetAllProducts()
        {
            var products = _repository.Get();

            // Sir-er AutoMapper Magic bebohar kore
            var mapper = MapperConfig.GetMapper();
            var productDtos = mapper.Map<List<ProductDto>>(products);

            return productDtos;
        }

        public ProductDto GetProductById(int id)
        {
            var product = _repository.Get(id);
            if (product == null) return null;

            // Single object mapping
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<ProductDto>(product);
        }

        public bool AddProduct(CreateProductDto createDto)
        {
            var mapper = MapperConfig.GetMapper();

            // dto theke ashol Entity-te map kora (ashol data db te jabe)
            var product = mapper.Map<Product>(createDto);

            return _repository.Create(product);
        }
    }
}
