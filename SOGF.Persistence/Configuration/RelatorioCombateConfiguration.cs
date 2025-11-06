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

        builder.Property(rc => rc.DescricaoTatica)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(rc => rc.FaccaoVencedoraId)
            .IsRequired();

        builder.OwnsMany(rc => rc.NavesEngajadas, owned =>
        {
            owned.ToTable("EngajamentosCombate");

            owned.WithOwner().HasForeignKey("RelatorioCombateId");

            owned.HasKey(e => e.Id);

            owned.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            owned.Property(e => e.NaveId)
                .IsRequired();

            owned.Property(e => e.DataAtualizacao)
                .ValueGeneratedOnUpdate();

            owned.Property(e => e.PilotoId)
                .IsRequired();

            owned.Property(e => e.MissaoId)
                .IsRequired();

            owned.Property(e => e.Resultado)
                .HasConversion<string>()
                .IsRequired();

            owned.HasIndex(
                    "RelatorioCombateId",
                    nameof(EngajamentoCombate.NaveId),
                    nameof(EngajamentoCombate.PilotoId))
                .IsUnique();
        });
    }
}