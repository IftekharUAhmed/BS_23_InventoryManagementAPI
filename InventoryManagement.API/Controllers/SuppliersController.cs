using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Application.Services;
using Microsoft.AspNetCore.Authorization;

namespace InventoryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]  //for authorization 
    public class SuppliersController : ControllerBase
    {
        private readonly SupplierService _supplierService;

        public SuppliersController(SupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SupplierDto>> GetAll()
        {
            return Ok(_supplierService.GetAllSuppliers());
        }

        [HttpGet("{id}")]
        public ActionResult<SupplierDto> Get(int id)
        {
            var supplier = _supplierService.GetSupplierById(id);
            if (supplier == null) return NotFound("db cant found supplier!");
            return Ok(supplier);
        }

        [HttpPost]
        public ActionResult Add([FromBody] CreateSupplierDto dto)
        {
            _supplierService.AddSupplier(dto);
            return Ok("supplier added succesfully!");
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] CreateSupplierDto dto)
        {
            _supplierService.UpdateSupplier(id, dto);
            return Ok("Supplier updateed");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _supplierService.DeleteSupplier(id);
            return Ok("Supplier deleted");
        }
    }
}
