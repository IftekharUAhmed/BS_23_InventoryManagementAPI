using System;
using System.Collections.Generic;
using System.Text;
using InventoryManagement.Domain.Entities;
 

namespace InventoryManagement.Application.Interfaces
{
    public interface ICategoryRepository
    {
        void Add(Category category);
        IEnumerable<Category> GetAll();
        Category GetById(int id);
        void Update(Category category);
        void Delete(Category category);
    }
}
