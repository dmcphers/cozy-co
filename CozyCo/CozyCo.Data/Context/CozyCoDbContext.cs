using CozyCo.Domain.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CozyCo.Data.Context
{

    // DbContext --> represent a session to a db and provides APIs
    // to communicate with the db
    public class CozyCoDbContext : IdentityDbContext<AppUser>
    {
        // Per Model that we want to turn into a table
        // we add it as a DbSet

        // represents a collection (table) of a given entity/model
        // they map to table by default
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<Lease> Leases { get; set; }

        // virtual method designed to be overriden
        // you can provide configuration for the context
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // connection string is divided into 3 elements
            // server - database - authentication
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=cozyco;Trusted_Connection=true");
        }

        // we can manipulate the models
        // add data to tables
        // change the default relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base = IdentityDbContext
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PropertyType>().HasData(
                    new PropertyType {Id=1, Description = "Condo"},
                    new PropertyType {Id=2, Description = "Single Family Home" },
                    new PropertyType {Id=3, Description = "Duplex" }
                );

            // Adding Lease as the table inbetween Property and AppUser

            modelBuilder.Entity<Lease>()
                .HasKey(l => new { l.PropertyId, l.TenantId}); // combined PK

            modelBuilder.Entity<Lease>() // Tenant is a AppUser
                .HasOne(l => l.Tenant)
                .WithMany(t => t.Leases) 
                .HasForeignKey(l => l.TenantId);

            modelBuilder.Entity<Lease>()
                .HasOne(l => l.Property)
                .WithMany(p => p.Leases)
                .HasForeignKey(l => l.PropertyId);
                
        }
    }
}
