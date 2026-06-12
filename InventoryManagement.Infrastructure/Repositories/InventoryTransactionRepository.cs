using InventoryManagement.Application.Interfaces;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagement.Infrastructure.Repositories
{
    public class InventoryTransactionRepository : IInventoryTransactionRepository
    {
        private readonly InventoryDbContext _context;
        public InventoryTransactionRepository(InventoryDbContext context) {
            _context = context; 
        }

        public void Add(InventoryTransaction transaction) 
        { _context.InventoryTransactions.Add(transaction);
          _context.SaveChanges();
        }
        public IEnumerable<InventoryTransaction> GetHistory()
        {
            return
                _context.InventoryTransactions.Include(t => t.Product).ToList();
        }
    }
}
