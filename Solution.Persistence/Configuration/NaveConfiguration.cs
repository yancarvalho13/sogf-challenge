using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solution.Domain.Model;

namespace Solution.Persistence.Configuration;

public class NaveConfiguration : IEntityTypeConfiguration<Nave>
{
    public void Configure(EntityTypeBuilder<Nave> builder)
    {
        builder.ToTable("Naves");
        builder.HasKey(nv => nv.Id);

        builder.Property(nv => nv.Id)
            .ValueGeneratedOnAdd();

        builder.Property(nv => nv.DataCriacao)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("getDate()");

        builder.Property(nv => nv.DataAtualizacao)
            .ValueGeneratedOnAddOrUpdate()
            .HasDefaultValueSql("getDate()");

        builder.Property(nv => nv.Nome)
            .IsRequired().HasMaxLength(256);

        builder.Property(nv => nv.Classe)
            .HasConversion<string>().IsRequired();

        builder.HasOne(nv => nv.Piloto)
            .WithOne(pilot => pilot.NavePilotada)
            .HasForeignKey<Tripulante>(e => e.NavePilotadaId);

        builder.HasMany(nv => nv.Tripulantes)
            .WithOne(tp => tp.NaveAtual)
            .HasForeignKey(tp => tp.NaveAtualId)
            .IsRequired(false);
        
        builder.Property(nv => nv.Status)
            .HasConversion<string>().IsRequired();

        builder.HasMany(nv => nv.Missoes)
            .WithOne(mss => mss.NaveDesignada)
            .HasForeignKey(mss => mss.NaveDesignadaId);
        
    }
}