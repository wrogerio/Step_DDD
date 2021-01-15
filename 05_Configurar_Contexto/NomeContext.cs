using Microsoft.EntityFrameworkCore;
using SolutionName.Domain.Entities;
using SolutionName.Infra.EntityConfig;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolutionName.Infra.Context
{
    public class NomeContext : DbContext
    {
        public DbSet<xpto> tbxpto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(getConnectionString());
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new xptoConfig());
        }
		
		public string getConnectionString()
        {
            return @"Data Source=.\sqlexpress;Initial Catalog=NomeBanco;Integrated Security=True";
        }
    }
}
