using AutoMapper;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Domain.Entities;

namespace InventoryManagement.Application
{
    public class MapperConfig
    {
        public static Mapper GetMapper()
        {
            
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDto>().ReverseMap();
                cfg.CreateMap<Product, CreateProductDto>().ReverseMap();
            });

            return new Mapper(config);
        }
    }
}
