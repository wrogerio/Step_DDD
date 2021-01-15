using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolutionName.Domain.Entities;

namespace SolutionName.Infra.EntityConfig
{
    public class ClassNameConfig : IEntityTypeConfiguration<ClassName>
    {
        public void Configure(EntityTypeBuilder<ClassName> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Documento).HasMaxLength(20);

            builder.Property(x => x.isAtivo).HasDefaultValue(true);

            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.CreatedAt).HasColumnType("DateTime");

            builder.HasMany(x => x.Veiculos).WithOne(x => x.ClassName).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
