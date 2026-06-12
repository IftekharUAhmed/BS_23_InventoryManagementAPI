using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Domain.Entities
{
    public class InventoryTransaction
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; } 

        public string TransactionType { get; set; } //stock in or stock out   
        public int Quantity { get; set; }  
        public DateTime TransactionDate { get; set; }  
        public string Remarks { get; set; } //for new notes or like new decans 
    }
}
