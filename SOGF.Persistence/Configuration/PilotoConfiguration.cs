using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOGF.Domain.Mocks;
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
            .ValueGeneratedOnAdd().HasDefaultValueSql("getDate()");
        builder.Property(p => p.DataAtualizacao)
            .ValueGeneratedOnUpdate().HasDefaultValueSql("getDate()");
        
        builder.Property(p => p.Nome)
            .IsRequired().HasMaxLength(256);

        builder.Property(p => p.Patente)
            .HasConversion<string>()
            .IsRequired();
        
        builder.HasData( 

        new Piloto(-1,"Luke Skywalker",  Patente.Capitao),
        new Piloto(-2,"Wedge Antilles",  Patente.Tenente),
        new Piloto(-3,"Poe Dameron",     Patente.Capitao),
        new Piloto(-4,"Biggs Darklighter", Patente.Tenente),
        new Piloto(-5,"Jek Porkins",     Patente.Tenente),
        new Piloto(-6,"Han Solo",        Patente.Tenente),
        new Piloto(-7,"Leia Organa",     Patente.Capitao),
        new Piloto(-8,"Cassian Andor",   Patente.Capitao),
        new Piloto(-9,"Jyn Erso",        Patente.Tenente),
        new Piloto(-10,"Tycho Celchu",    Patente.Tenente),
        new Piloto(-11,"Wes Janson",      Patente.Tenente),
        new Piloto(-12,"Garven Dreis",    Patente.Capitao));

    }
}