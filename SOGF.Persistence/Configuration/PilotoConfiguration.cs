using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOGF.Domain.Model;

namespace Solution.Persistence.Configuration;

public class PilotoConfiguration : IEntityTypeConfiguration<Piloto>
{
    public void Configure(EntityTypeBuilder<Piloto> builder)
    {
        builder.ToTable("Pilotos");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd();
        builder.Property(p => p.DataCriacao)
            .IsRequired();
        builder.Property(p => p.DataAtualizacao)
            .ValueGeneratedOnUpdate();
        
        builder.Property(p => p.Nome)
            .IsRequired().HasMaxLength(256);

        builder.Property(p => p.Patente)
            .HasConversion<string>()
            .IsRequired();
    }
}