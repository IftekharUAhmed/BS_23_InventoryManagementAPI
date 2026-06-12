using System;
using System.Collections.Generic;
using System.Text;
 using System.Linq;
using InventoryManagement.Application.Interfaces;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Infrastructure.Data;

namespace InventoryManagement.Infrastructure.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly InventoryDbContext _context;

        public SupplierRepository(InventoryDbContext context)
        {
            _context = context;
        }

        public void Add(Supplier supplier) {
        _context.Suppliers.Add(supplier); 
        _context.SaveChanges(); 
        }
        public IEnumerable<Supplier> GetAll() { 
        return 
        _context.Suppliers.ToList(); 
        }
        public Supplier GetById(int id) { 
        return 
        _context.Suppliers.FirstOrDefault(s => s.Id == id);
        }
        public void Update(Supplier supplier) {
        _context.Suppliers.Update(supplier); 
        _context.SaveChanges(); 
        }
        public void Delete(Supplier supplier) {
        _context.Suppliers.Remove(supplier); 
        _context.SaveChanges(); 
        }
    }
}
