using CozyCo.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CozyCo.Data.Interfaces
{
    public interface IPropertyTypeRepository
    {
        // read
        PropertyType GetById(int id);
        ICollection<PropertyType> GetAll();

    }
}
