using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solution.Domain.Model;

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
            .ValueGeneratedOnAdd();
        
        builder.Property(t => t.DataAtualizacao)
            .ValueGeneratedOnAddOrUpdate();

        builder.Property(t => t.Nome)
            .IsRequired().HasMaxLength(256);

        builder.Property(t => t.Patente)
            .HasConversion<string>()
            .IsRequired();

        builder.Property(t => t.Especialidade)
            .HasConversion<string>()
            .IsRequired();

        builder.HasMany(t => t.HistoricoDeCombates)
            .WithOne(rc => rc.PilotoVencedor)
            .HasForeignKey(rc => rc.PilotoVencedorId)
            .IsRequired();

    }
}