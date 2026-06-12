using InventoryManagement.Application.DTOs;
using InventoryManagement.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InventoryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryService _inventoryService;
        public InventoryController(InventoryService inventoryService) { 
        _inventoryService = inventoryService; 
        }

        [HttpPost("stock-in")]
        public ActionResult StockIn([FromBody] StockTransactionDto dto) { 
        _inventoryService.StockIn(dto);
        return 
        Ok("Stock In Successful!");
        }

        [HttpPost("stock-out")]
        public ActionResult StockOut([FromBody] StockTransactionDto dto) 
        { _inventoryService.StockOut(dto);
        return 
        Ok("Stock Out Successful!"); 
        }

        [HttpGet("history")]
        public ActionResult<IEnumerable<InventoryHistoryDto>> GetHistory() { 
        return 
        Ok(_inventoryService.GetHistory());
        }
    }
}
