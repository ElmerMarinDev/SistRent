using SistRent.Application.DTOs;
using SistRent.Application.Interfaces;
using SistRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistRent.Application.Services
{
    public class PropertyService(IPropertyRepository _repo)
    {
        public async Task<IEnumerable<PropertyResponseDto>> GeTAsync()
        {
            var property = await _repo.GetAsync();

            return property.Select(e => new PropertyResponseDto(
                IdProperty: e.IdProperty,
                Name: e.Name,
                Address: e.Address,
                Description: e.Description,
                Status: e.Status,
                RegistrationDate:e.CreatedAt
                ));


        }


        public async Task AddAsync(PropertyCreateDto property)
        {

            if (string.IsNullOrEmpty(property.Name)) throw new ValidationException("Full Name id is requeried");
            if (string.IsNullOrEmpty(property.Address)) throw new ValidationException("Email id is requeried");
            if (string.IsNullOrEmpty(property.Description)) throw new ValidationException("Email id is requeried");

            var newProperty = new Property
            {
                Name = property.Name,
                Address= property.Address,
                Description= property.Description,
                Status= property.Status,
            };

            await _repo.AddAsync(newProperty);
        }


        public Property UpdateData(PropertyUpdateDto property, Property existingProperty)
        {

            if (existingProperty.Name != property.Name)
                existingProperty.Name = property.Name;

            if (existingProperty.Description != property.Description)
                existingProperty.Description = property.Description;

            if (existingProperty.Status != property.Status)
                existingProperty.Status = property.Status;


            return existingProperty;

        }


        public async Task UpdateAsync(PropertyUpdateDto property)
        {
            if (property.IdProperty == 0) throw new ValidationException("Property id is requeried");
            if (string.IsNullOrEmpty(property.Name)) throw new ValidationException("Name id is requeried");
            if (string.IsNullOrEmpty(property.Address)) throw new ValidationException("Adress id is requeried");

            var existingProperty = await _repo.GetByIdAsync(property.IdProperty);

            if (existingProperty is null) throw new ValidationException("Property not found");

            UpdateData(property, existingProperty);
            await _repo.EditAsync(existingProperty);
        }

        public async Task DeleteAsync(int id)
        {
            if (id == 0) throw new ValidationException("Property id is requeried");
            await _repo.DeleteAsync(id);

        }

    }

}

