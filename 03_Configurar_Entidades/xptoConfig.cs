using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MWEstacionamentos.Domain.Entities;

namespace MWEstacionamentos.Infra.EntityConfig
{
    public class xptoConfig : IEntityTypeConfiguration<xpto>
    {
        public void Configure(EntityTypeBuilder<xpto> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Documento).HasMaxLength(20);

            builder.Property(x => x.isAtivo).HasDefaultValue(true);

            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.CreatedAt).HasColumnType("DateTime");

            builder.HasMany(x => x.Veiculos).WithOne(x => x.xpto).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
