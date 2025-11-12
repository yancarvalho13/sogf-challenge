using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;
using SOGF.Domain.Mocks;
using SOGF.Domain.Model;

namespace Solution.Persistence.Configuration;

public class FaccaoConfiguration : IEntityTypeConfiguration<Faccao>
{
    public void Configure(EntityTypeBuilder<Faccao> builder)
    {
        builder.ToTable("Faccoes");
        builder.HasKey(f => f.Id);
        
        builder.Property(f => f.Id)
            .ValueGeneratedOnAdd();

        builder.Property(f => f.DataCriacao)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("getDate()");
        builder.Property(f => f.DataAtualizacao)
            .ValueGeneratedOnUpdate().HasDefaultValueSql("getDate()");
        
        builder.Property(f => f.Nome)
            .IsRequired().HasMaxLength(256);
        
        builder.Property(f => f.NivelAmeaca)
            .HasConversion<string>()
            .IsRequired();
        
        builder.Property(f => f.StatusDiplomatico)
            .HasConversion<string>()
            .IsRequired();
        
        builder.HasData( new Faccao(1,"Império Galáctico", StatusDiplomatico.Agressivo, NivelAmeaca.Alto),
            new Faccao(2, "Aliança Rebelde", StatusDiplomatico.Pacifico, NivelAmeaca.Alto),
            new Faccao(3, "Nova República",      StatusDiplomatico.Pacifico, NivelAmeaca.Baixo),
            new Faccao(4, "Primeira Ordem",      StatusDiplomatico.Agressivo, NivelAmeaca.Alto),
            new Faccao(5, "Resistência",         StatusDiplomatico.Pacifico, NivelAmeaca.Medio),
            new Faccao(6, "Guilda de Caçadores", StatusDiplomatico.Neutro, NivelAmeaca.Medio),
            new Faccao(7, "Clãs Mandalorianos",  StatusDiplomatico.Neutro, NivelAmeaca.Medio),
            new Faccao(8, "Sindicatos Hutt",     StatusDiplomatico.Neutro, NivelAmeaca.Alto));
        
        
    }
}