﻿using CozyCo.Data.Context;
using CozyCo.Data.Interfaces;
using CozyCo.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CozyCo.Data.Implementation.SqlServer
{
    public class SqlServerPropertyRepository : IPropertyRepository
    {
        public Property Create(Property newProperty)
        {
            using (var context = new CozyCoDbContext())
            {
                context.Properties.Add(newProperty);
                context.SaveChanges();

                return newProperty; // newProperty.Id will be populated with new DB value
            }
        }

        public Property GetById(int id)
        {
            using (var context = new CozyCoDbContext())
            {
                // SQL -> database look for table properties
                // if none found then return null value rather than an exception
                var property = context.Properties.SingleOrDefault(p => p.Id == id);
                return property;
            }
        }

        public ICollection<Property> GetAllProperties()
        {
            using (var context = new CozyCoDbContext())
            {
                // DbSet != ICollection
                return context.Properties
                    .ToList(); // now it is ICollection
            }
        }

        public Property Update(Property updatedProperty)
        {
            using (var context = new CozyCoDbContext())
            {
                // find the old entity
                var oldProperty = GetById(updatedProperty.Id);

                // update each entity properties / get;set;
                context.Entry(oldProperty).CurrentValues.SetValues(updatedProperty);

                // save changes
                context.Properties.Update(oldProperty);
                context.SaveChanges();
                return oldProperty; // to ensure that the save happened
            }
        }

        public bool Delete(int id)
        {
            using (var context = new CozyCoDbContext())
            {
                // find what we are going to delete
                var propertyToBeDeleted = GetById(id);

                // delete
                context.Properties.Remove(propertyToBeDeleted);

                // save changes
                context.SaveChanges();

                // check if entity/model exist
                if(GetById(id) == null)
                {
                    return true;
                }

                return false;
            }

        }

        
    }
}
