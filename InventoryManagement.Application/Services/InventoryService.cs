using AutoMapper;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Application.Interfaces;
using InventoryManagement.Domain.Entities;
using System;
using System.Collections.Generic;

namespace InventoryManagement.Application.Services
{
    public class InventoryService
    {
        private readonly IInventoryTransactionRepository _inventoryRepo;
        private readonly IProductRepository _productRepo; //for stock update
        private readonly IMapper _mapper;

        public InventoryService(IInventoryTransactionRepository inventoryRepo, IProductRepository productRepo, IMapper mapper)
        {
            _inventoryRepo = inventoryRepo;
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public void StockIn(StockTransactionDto dto)
        {
            var product = _productRepo.GetById(dto.ProductId);
            if (product != null)
            {
                //stock update
                product.StockQuantity += dto.Quantity;
                _productRepo.Update(product);
            
                var transaction = new InventoryTransaction
                {
                    ProductId = dto.ProductId,
                    TransactionType = "StockIn",
                    Quantity = dto.Quantity,
                    TransactionDate = DateTime.Now,
                    Remarks = dto.Remarks
                };
                _inventoryRepo.Add(transaction);
            }
        }

        public void StockOut(StockTransactionDto dto)
        {
            var product = _productRepo.GetById(dto.ProductId);
            //last check before the stock out 
            if (product != null && product.StockQuantity >= dto.Quantity)
            {
                product.StockQuantity -= dto.Quantity;
                _productRepo.Update(product);

                var transaction = new InventoryTransaction
                {
                    ProductId = dto.ProductId,
                    TransactionType = "StockOut",
                    Quantity = dto.Quantity,
                    TransactionDate = DateTime.Now,
                    Remarks = dto.Remarks
                };
                _inventoryRepo.Add(transaction);
            }
        }

        public IEnumerable<InventoryHistoryDto> GetHistory()
        {
            return _mapper.Map<IEnumerable<InventoryHistoryDto>>(_inventoryRepo.GetHistory());
        }
    }
}