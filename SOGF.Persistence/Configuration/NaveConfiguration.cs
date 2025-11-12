using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOGF.Domain.Mocks;
using SOGF.Domain.Model;

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

        builder.Property(nv => nv.CapacidadeTripulacao)
            .IsRequired();
        
        builder.Property(nv => nv.Status)
            .HasConversion<string>().IsRequired();
        
        builder.HasOne(nv => nv.Faccao)
            .WithMany(f => f.Naves)
            .HasForeignKey(nv => nv.FaccaoId)
            .OnDelete(DeleteBehavior.Restrict);
       builder.HasData(
            new Nave(1,"Home One",TipoNave.CruzadorDeBatalha, 5400,  StatusOperacional.Pronta,   1),
        new Nave(2,"Liberty (MC80)",      TipoNave.CruzadorDeBatalha, 5200,  StatusOperacional.Pronta,   2),
        new Nave(3,"Millennium Falcon",   TipoNave.Utilitario,         6,     StatusOperacional.Pronta,   4),
        new Nave(4,"Ghost",               TipoNave.Utilitario,         6,     StatusOperacional.Pronta,   5),
        new Nave(5,"Red Five (X-Wing)",   TipoNave.Patrulha,           1,     StatusOperacional.Pronta,   2),
        new Nave(6,"Gold Leader (Y-Wing)",TipoNave.Patrulha,           2,     StatusOperacional.EmReparo, 1),
        new Nave(7,"Devastator (ISD)",    TipoNave.CruzadorDeBatalha, 37000, StatusOperacional.Pronta,   6),
        new Nave(8,"Interdictor",         TipoNave.CruzadorDeBatalha, 28000, StatusOperacional.Pronta,   2),
        new Nave(9,"TIE Squadron",        TipoNave.Patrulha,           1,     StatusOperacional.Pronta,   4),
        new Nave(10,"Finalizer (SD FO)",   TipoNave.CruzadorDeBatalha, 60000, StatusOperacional.EmReparo, 2),
        // Neutro / Outros
        new Nave(11,"Slave I",             TipoNave.Utilitario,         1,     StatusOperacional.Pronta,   6),
        new Nave(12,"Gauntlet Fighter",    TipoNave.Patrulha,           1,     StatusOperacional.Pronta,   7),
        new Nave(13,"Khetanna",            TipoNave.Utilitario,         90,    StatusOperacional.Pronta,   8));
        
    }
}