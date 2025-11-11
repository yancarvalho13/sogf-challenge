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
            .ValueGeneratedOnAdd().HasDefaultValueSql("getDate()");
        builder.Property(mss => mss.DataAtualizacao)
            .ValueGeneratedOnUpdate().HasDefaultValueSql("getDate()");

        builder.Property(mss => mss.ObjetivoMissao)
            .IsRequired();
        
        builder.Property(mss => mss.SetorGalatico)
            .IsRequired();
        
        builder.Property(mss => mss.StatusMissao)
            .IsRequired();

        builder.Property(mss => mss.NaveId)
            .IsRequired();
        
        builder.Property(mss => mss.PilotoId)
            .IsRequired();

        builder.OwnsMany(mss => mss.Tripulantes, owned =>
        {
            owned.ToTable("missaoTripulantes");
            
            owned.WithOwner().HasForeignKey("MissaoId");

            owned.HasKey("Id");
            owned.Property<long>("Id").ValueGeneratedOnAdd();

            
            owned.Property(x => x.TripulanteId)
                .HasColumnName("TripulanteId")
                .IsRequired();
            
            owned.HasIndex("MissaoId", nameof(MissaoTripulantes.TripulanteId))
                .IsUnique();
        });


    }
}