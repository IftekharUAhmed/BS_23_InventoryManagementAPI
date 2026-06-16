using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Domain.Entities;

namespace InventoryManagement.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> UserExistsAsync(string username);
        Task<User> GetUserByUsernameAsync(string username);
        Task AddUserAsync(User user);
    }
}