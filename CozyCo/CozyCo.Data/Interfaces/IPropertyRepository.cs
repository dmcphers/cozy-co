using CozyCo.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CozyCo.Data.Interfaces
{
    public interface IPropertyRepository
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
}
