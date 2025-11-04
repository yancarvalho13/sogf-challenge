using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solution.Domain.Model;

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
        
    }
}