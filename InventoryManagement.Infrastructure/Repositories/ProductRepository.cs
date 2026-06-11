using InventoryManagement.Application.Interfaces;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagement.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly InventoryDbContext db;

        public ProductRepository(InventoryDbContext db)
        {
            this.db = db;
        }

        public List<Product> Get()
        {
            return db.Products.ToList();
        }

        public Product Get(int id)
        {
            return db.Products.Find(id);  
        }

        public bool Create(Product p)
        {
            db.Products.Add(p);
            return db.SaveChanges() > 0;
        }

        public bool Update(Product p)
        {
            var exobj = Get(p.Id);
            if (exobj == null) return false;

            db.Entry(exobj).CurrentValues.SetValues(p);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            if (exobj == null) return false;

            db.Products.Remove(exobj);
            return db.SaveChanges() > 0;
        }
    }
}