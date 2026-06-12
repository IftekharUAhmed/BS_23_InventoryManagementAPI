using System;
using System.Collections.Generic;
using System.Text;

 
namespace InventoryManagement.Application.DTOs
{
    public class InventoryHistoryDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string TransactionType { get; set; }
        public int Quantity { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Remarks { get; set; }
    }
}
