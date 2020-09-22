using BuildingData.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingData.Repository
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public ApplicationContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Reading>(eb =>
                {
                    eb.HasNoKey();
                });
        }
        public DbSet<Building> Building { get; set; }
        public DbSet<BuildingData.Model.Object> Object { get; set; }
        public DbSet<DataField> DataField { get; set; }
        public DbSet<Reading> Reading { get; set; }
    }
}
