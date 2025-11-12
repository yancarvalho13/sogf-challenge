using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOGF.Domain.Mocks;
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
        
        builder.HasData(
            new Tripulante(1,"Luke Skywalker",    Patente.Capitao, Especialidade.Estrategista),
        new Tripulante(2,"Wedge Antilles",    Patente.Tenente, Especialidade.Medicina),
        new Tripulante(3,"Chewbacca",         Patente.Tenente, Especialidade.Engenharia),
        new Tripulante(4,"Leia Organa",       Patente.Capitao, Especialidade.Batalha),
        new Tripulante(5,"Han Solo",          Patente.Tenente, Especialidade.Engenharia),
        new Tripulante(6,"Poe Dameron",       Patente.Capitao, Especialidade.Estrategista),
        new Tripulante(7,"Finn",              Patente.Cadete,  Especialidade.Medicina),
        new Tripulante(8,"Rey",               Patente.Tenente, Especialidade.Batalha),
        new Tripulante(9,"Rose Tico",         Patente.Cadete,  Especialidade.Engenharia),
        new Tripulante(10,"Biggs Darklighter", Patente.Tenente, Especialidade.Medicina),
        new Tripulante(11,"Jek Porkins",       Patente.Tenente, Especialidade.Batalha),
        new Tripulante(12,"Dak Ralter",        Patente.Cadete,  Especialidade.Engenharia),
        new Tripulante(13,"Lando Calrissian",  Patente.Capitao, Especialidade.Batalha),
        new Tripulante(14,"Nien Nunb",         Patente.Tenente, Especialidade.Engenharia),
        new Tripulante(15,"Bodhi Rook",        Patente.Tenente, Especialidade.Engenharia),
        new Tripulante(16,"Cassian Andor",     Patente.Capitao, Especialidade.Medicina),
        new Tripulante(17,"Jyn Erso",          Patente.Tenente, Especialidade.Medicina),
        new Tripulante(18,"Sabine Wren",       Patente.Tenente, Especialidade.Engenharia),
        new Tripulante(19,"Hera Syndulla",     Patente.Capitao, Especialidade.Batalha));
    }
}