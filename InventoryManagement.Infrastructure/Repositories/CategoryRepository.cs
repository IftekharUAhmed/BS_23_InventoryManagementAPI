using InventoryManagement.Application.Interfaces;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagement.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly InventoryDbContext _context;
        public CategoryRepository(InventoryDbContext context) {
            _context = context;
        }

        public void Add(Category category)
        { _context.Categories.Add(category); _context.SaveChanges();
        }
        public IEnumerable<Category> GetAll() {
            return 
           _context.Categories.ToList();
        }
        public Category GetById(int id) {
            return 
         _context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public void Delete(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}