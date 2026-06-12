using System;
using System.Collections.Generic;
using System.Text;
using InventoryManagement.Domain.Entities;

namespace InventoryManagement.Application.Interfaces
{
    public interface ISupplierRepository
    {
        void Add(Supplier supplier);
        IEnumerable<Supplier> GetAll();
        Supplier GetById(int id);
        void Update(Supplier supplier);
        void Delete(Supplier supplier);
       
    }
}