using System;
using System.Collections.Generic;
using System.Text;
using InventoryManagement.Domain.Entities;
using System.Collections.Generic;

namespace InventoryManagement.Application.Interfaces
{
    public interface IProductRepository
    {
        List<Product> Get();
        Product Get(int id);
        bool Create(Product p);
        bool Update(Product p);
        bool Delete(int id);
    }
}
