using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOGF.Domain.Model;

namespace Solution.Persistence.Configuration;

public class MissaoConfiguration : IEntityTypeConfiguration<Missao>
{
    public void Configure(EntityTypeBuilder<Missao> builder)
    {
        
        builder.ToTable("missoes");

        builder.HasKey(mss => mss.Id);

        builder.Property(mss => mss.Id)
            .ValueGeneratedOnAdd();
        builder.Property(mss => mss.DataCriacao)
            .ValueGeneratedOnAdd();
        builder.Property(mss => mss.DataAtualizacao)
            .ValueGeneratedOnAddOrUpdate();

        builder.Property(mss => mss.Descricao)
            .IsRequired();

        builder.Property(mss => mss.Status)
            .HasConversion<string>()
            .IsRequired();


    }
}