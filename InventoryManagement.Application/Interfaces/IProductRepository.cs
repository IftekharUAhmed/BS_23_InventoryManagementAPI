using System;
using System.Collections.Generic;
using System.Text;
using InventoryManagement.Domain.Entities;
 
namespace InventoryManagement.Application.Interfaces
{
    public interface IProductRepository
    {
        void Add(Product product);                 
        void Update(Product product);              
        void Delete(Product product);              
        Product GetById(int id);                   
        IEnumerable<Product> Search(string name); // product search by id 
    }
}
