using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOGF.Domain.Model;

namespace Solution.Persistence.Configuration;

public class RelatorioCombateConfiguration : IEntityTypeConfiguration<RelatorioCombate>
{
    public void Configure(EntityTypeBuilder<RelatorioCombate> builder)
    {
        builder.ToTable("relatorioCombate");

        builder.HasKey(rc => rc.Id);

        builder.Property(rc => rc.Id)
            .ValueGeneratedOnAdd();
        builder.Property(rc => rc.DataCriacao)
            .ValueGeneratedOnAdd();
        builder.Property(rc => rc.DataAtualizacao)
            .ValueGeneratedOnAddOrUpdate();
        
        builder.Property(rc => rc.Data)
            .HasColumnType("date");
        
        builder.Property(rc => rc.Resultado)
            .HasConversion<string>()
            .IsRequired();

        builder.HasOne(rc => rc.PilotoVencedor)
            .WithMany(p => p.Vitorias)
            .HasForeignKey(rc => rc.PilotoPerdedorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(rc => rc.PilotoPerdedor)
            .WithMany(p => p.Derrotas)
            .HasForeignKey(rc => rc.PilotoPerdedorId)
            .OnDelete(DeleteBehavior.Restrict);
            
        builder.ToTable(t => 
            t.HasCheckConstraint("CK_PilotoVencedorId_PilotoPerdedorId",
                "[PilotoVencedorId] <> [PilotoPerdedorId]"));

        builder.HasIndex(rc => new { rc.PilotoVencedorId, rc.PilotoPerdedorId });
    }
}