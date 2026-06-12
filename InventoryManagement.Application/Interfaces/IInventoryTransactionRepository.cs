using System;
using System.Collections.Generic;
using System.Text;
using InventoryManagement.Domain.Entities;
 

namespace InventoryManagement.Application.Interfaces
{
    public interface IInventoryTransactionRepository
    {
        void Add(InventoryTransaction transaction);
        IEnumerable<InventoryTransaction> GetHistory();
    }
}
