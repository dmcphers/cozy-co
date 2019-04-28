using CozyCo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CozyCo.Data.Context
{

    // This class will translate models into database tables
    public class CozyCoDbContext : DbContext
    {
        // Per Model that we want to turn into a table
        // we add it as a DbSet

        DbSet<Property> Properties { get; set; }
    }
}
