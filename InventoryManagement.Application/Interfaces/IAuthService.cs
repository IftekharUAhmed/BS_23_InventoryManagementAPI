using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.DTOs;

namespace InventoryManagement.Application.Interfaces
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterDto dto);
        Task<string> LoginAsync(LoginDto dto);
    }
}
