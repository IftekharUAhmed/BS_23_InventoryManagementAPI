using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Application.Services;
using Microsoft.AspNetCore.Authorization; 

namespace InventoryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] //  
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

         ///<summary>
        /// search and get all api
        /// </summary>  
        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> Search([FromQuery] string name = "")
        {
            int test = 1;
            var products = _productService.SearchProducts(name);
            return Ok(products);
        }
 
        [HttpGet("{id}")]
        public ActionResult<ProductDto> Get(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null) return NotFound(" db cant found!");
            return Ok(product);
        }

        //cretae api  
        [HttpPost]
        public ActionResult Add([FromBody] CreateProductDto productDto)
        {
            _productService.AddProduct(productDto);
            return Ok(" added new product");
        }

        //update api  
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] CreateProductDto productDto)
        {
            _productService.UpdateProduct(id, productDto);
            return Ok("Product updated successfully  !");
        }

        //delete api 
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);
            return Ok("Product deleted!");
        }
    }
}
