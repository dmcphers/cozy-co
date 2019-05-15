using CozyCo.Data.Interfaces;
using CozyCo.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CozyCo.Service.Services
{
    public interface IPropertyService
    {
        // create
        Property Create(Property newProperty);

        // read
        Property GetById(int id);
        ICollection<Property> GetAllProperties();

        // update
        Property Update(Property updatedProperty);

        // delete
        bool Delete(int id);


    }

    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository; // -> null

        // added a dependency to the constructor
        public PropertyService(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository; // --> not be null anymore
        }

        public ICollection<Property> GetAllProperties()
        {
            return _propertyRepository.GetAllProperties();
        }

        public Property Create(Property newProperty)
        {
           return _propertyRepository.Create(newProperty); // create() is from repository
        }

        public bool Delete(int id)
        {
            return _propertyRepository.Delete(id);
        }

        public Property GetById(int id)
        {
            return _propertyRepository.GetById(id);
        }

        public Property Update(Property updatedProperty)
        {
            return _propertyRepository.Update(updatedProperty);
        }
    }
}
