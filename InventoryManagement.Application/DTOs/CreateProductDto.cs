using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.DTOs
{
    public class CreateProductDto
    {
        // Ekhane Id nei, karon user theke Id neya hobe na
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
