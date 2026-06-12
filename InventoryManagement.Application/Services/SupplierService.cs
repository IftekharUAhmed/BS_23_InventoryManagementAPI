using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Application.Interfaces;
using InventoryManagement.Domain.Entities;

namespace InventoryManagement.Application.Services
{
    public class SupplierService
    {
        private readonly ISupplierRepository _repository;
        private readonly IMapper _mapper;

        public SupplierService(ISupplierRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //for create 
        public void AddSupplier(CreateSupplierDto dto)
        {
            var supplier = _mapper.Map<Supplier>(dto);
            _repository.Add(supplier);
        }

        public IEnumerable<SupplierDto> GetAllSuppliers()
        {
            var suppliers = _repository.GetAll();
            return _mapper.Map<IEnumerable<SupplierDto>>(suppliers);
        }
        //get by id
        public SupplierDto GetSupplierById(int id)
        {
            var supplier = _repository.GetById(id);
            return _mapper.Map<SupplierDto>(supplier);
        }
        //for update 
        public void UpdateSupplier(int id, CreateSupplierDto dto)
        {
            var supplier = _repository.GetById(id);
            if (supplier != null)
            {
                _mapper.Map(dto, supplier);
                _repository.Update(supplier);
            }
        }
        //for delete 
        public void DeleteSupplier(int id)
        {
            var supplier = _repository.GetById(id);
            if (supplier != null)
            {
                _repository.Delete(supplier);
            }
        }
    }
}