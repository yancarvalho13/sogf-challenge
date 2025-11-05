using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOGF.Domain.Model;

namespace Solution.Persistence.Configuration;

public class TripulanteConfiguration : IEntityTypeConfiguration<Tripulante>
{
    public void Configure(EntityTypeBuilder<Tripulante> builder)
    {
        builder.ToTable("Tripulantes");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id)
            .ValueGeneratedOnAdd();

        builder.Property(t => t.DataCriacao)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("getDate()");
        
        builder.Property(t => t.DataAtualizacao)
            .ValueGeneratedOnAddOrUpdate()
            .HasDefaultValueSql("getDate()");

        builder.Property(t => t.Nome)
            .IsRequired().HasMaxLength(256);

        builder.Property(t => t.Patente)
            .HasConversion<string>()
            .IsRequired();

        builder.Property(t => t.Especialidade)
            .HasConversion<string>()
            .IsRequired();
    }
}