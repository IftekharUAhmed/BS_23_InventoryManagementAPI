using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; } //this  passwordhash dont show actual password this just show the hash  
        public string Role { get; set; }  //this for defining role like user , admin 
    }
}
