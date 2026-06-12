using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.DTOs
{
    public class StockTransactionDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Remarks { get; set; }
    }
}