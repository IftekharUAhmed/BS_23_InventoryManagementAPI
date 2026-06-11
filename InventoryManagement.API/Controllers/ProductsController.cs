using Microsoft.AspNetCore.Mvc;
using InventoryManagement.Application.Services;
using InventoryManagement.Application.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace InventoryManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null) return NotFound("Product not found");

            return Ok(product);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create([FromBody] CreateProductDto createDto)
        {
            var isCreated = _productService.AddProduct(createDto);
            if (isCreated)
            {
                return Ok("Product created successfully!");
            }
            return BadRequest("Failed to create product.");
        }
    }
}
