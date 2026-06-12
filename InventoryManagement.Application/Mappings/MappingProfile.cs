using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Domain.Entities;

namespace InventoryManagement.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //for product mapping         
            CreateMap<CreateProductDto, Product>();  
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier != null ? src.Supplier.Name : "no supplier"));
            //for supplier mapping
            CreateMap<CreateSupplierDto, Supplier>();
            CreateMap<Supplier, SupplierDto>();
            //for ctegory
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<Category, CategoryDto>();
            //fior transection
            CreateMap<InventoryTransaction, InventoryHistoryDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));
        }
    }
}

