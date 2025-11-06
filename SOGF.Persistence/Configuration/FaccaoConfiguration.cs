using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
            .IsRequired()
            ;
        builder.Property(f => f.DataAtualizacao)
            .ValueGeneratedOnUpdate();
        
        builder.Property(f => f.Nome)
            .IsRequired().HasMaxLength(256);
        
        builder.Property(f => f.NivelAmeaca)
            .HasConversion<string>()
            .IsRequired();
        
        builder.Property(f => f.StatusDiplomatico)
            .HasConversion<string>()
            .IsRequired();
    }
}