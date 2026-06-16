using System;
using System.Collections.Generic;
using System.Text;
namespace InventoryManagement.Application.DTOs
{
    public class RegisterDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}