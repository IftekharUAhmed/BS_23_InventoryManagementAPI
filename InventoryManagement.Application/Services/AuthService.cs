using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Application.Interfaces;
using InventoryManagement.Application.Utils;
using InventoryManagement.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace InventoryManagement.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;

        public AuthService(IUserRepository userRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            _config = config;
        }

        public async Task<string> RegisterAsync(RegisterDto dto)
        {
            if (await _userRepository.UserExistsAsync(dto.Username))
                return "User already exists!";

            var user = new User
            {
                Username = dto.Username,
                PasswordHash = PasswordHasher.HashPassword(dto.Password),
                Role = dto.Role
            };

            await _userRepository.AddUserAsync(user);
            return "User registered successfully!";
        }

        public async Task<string> LoginAsync(LoginDto dto)
        {
            var user = await _userRepository.GetUserByUsernameAsync(dto.Username);

            if (user == null || !PasswordHasher.VerifyPassword(dto.Password, user.PasswordHash))
                return null;

            return GenerateJwtToken(user.Username, user.Role);
        }

        private string GenerateJwtToken(string username, string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role)
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
