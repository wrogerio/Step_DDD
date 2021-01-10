using Microsoft.EntityFrameworkCore;
using MWEstacionamentos.Domain.Entities;
using MWEstacionamentos.Infra.EntityConfig;
using System;
using System.Collections.Generic;
using System.Text;

namespace MWEstacionamentos.Infra.Context
{
    public class MWContext : DbContext
    {
        public DbSet<Cliente> tbClientes { get; set; }
        public DbSet<Usuario> tbUsuarios { get; set; }
        public DbSet<Utilizacao> tbUtilizacoes { get; set; }
        public DbSet<Veiculo> tbVeiculos { get; set; }
        public DbSet<Preco> tbPrecos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=.\sqlexpress;Initial Catalog=MWEstacionamentos;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ClienteConfig());
            modelBuilder.ApplyConfiguration(new PrecoConfig());
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new UtilizacaoConfig());
            modelBuilder.ApplyConfiguration(new VeiculoConfig());
        }
    }
}
