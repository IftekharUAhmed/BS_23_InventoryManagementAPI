using InventoryManagement.Application.Utils;   
using InventoryManagement.Domain.Entities;  
using InventoryManagement.Infrastructure.Data;  
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;  
using System.Security.Claims;
using System.Text;

namespace InventoryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly InventoryDbContext _context;    
        public AuthController(IConfiguration config, InventoryDbContext context)
        {
            _config = config;
            _context = context;
        }

        //register api
        [HttpPost("register")]
        public IActionResult Register(string username, string password, string role)
        {
            //check user exist or not 
            if (_context.Users.Any(u => u.Username == username))
                return BadRequest("User already exists!");

            var user = new User
            {
                Username = username,
                PasswordHash = PasswordHasher.HashPassword(password), 
                Role = role
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok("User registered successfully!");
        }

        //login api
        [HttpPost("login")]
        public IActionResult Login(string username, string password)
        {
            //searching actual user from database  
            var user = _context.Users.FirstOrDefault(u => u.Username == username);

           //if user cant find or pass hash dont matched then through a error
            if (user == null || !PasswordHasher.VerifyPassword(password, user.PasswordHash))
            {
                return Unauthorized("Invalid Credentials");
            }

            //method for make token
            var token = GenerateJwtToken(user.Username, user.Role);
            return Ok(new { Token = token });
        }

        
        private string GenerateJwtToken(string username, string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //for token 
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role)
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30), // 30 minute  for expired time
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}