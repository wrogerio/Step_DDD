using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MWEstacionamentos.Domain.Entities;

namespace MWEstacionamentos.Infra.EntityConfig
{
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Documento).HasMaxLength(20);
            builder.Property(x => x.Endereco).HasMaxLength(120);
            builder.Property(x => x.Fone).HasMaxLength(15);
            builder.Property(x => x.Modo).HasMaxLength(12);
            builder.Property(x => x.Nome).HasMaxLength(70);
            builder.Property(x => x.Tipo).HasMaxLength(15);

            builder.Property(x => x.isAtivo).HasDefaultValue(true);

            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.CreatedAt).HasColumnType("DateTime");

            builder.HasMany(x => x.Veiculos).WithOne(x => x.Cliente).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
