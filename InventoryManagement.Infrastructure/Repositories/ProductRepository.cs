using System.Collections.Generic;
using System.Linq;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Application.Interfaces;
using InventoryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly InventoryDbContext _context;

        public ProductRepository(InventoryDbContext context)
        {
            _context = context;
        }
        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        } 
        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
        public void Delete(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
        public Product GetById(int id)
        {
            
            return _context.Products.Include(p => p.Supplier).FirstOrDefault(p => p.Id == id);
        }
        public IEnumerable<Product> Search(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return _context.Products.Include(p => p.Supplier).ToList();
            }

            return _context.Products.Include(p => p.Supplier)
                .Where(p => p.Name.Contains(name)).ToList();
        }
    }
}