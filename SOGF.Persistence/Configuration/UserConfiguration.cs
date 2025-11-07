using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOGF.Domain;
using SOGF.Domain.Entity;
using SOGF.Domain.Model;

namespace Solution.Persistence.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("usuarios");
        
        builder.HasKey(u => u.Id);
        
        builder.Property(u => u.Id)
            .ValueGeneratedOnAdd();

        builder.Property(u => u.DataCriacao)
            .IsRequired();

        builder.Property(u => u.DataAtualizacao)
            .ValueGeneratedOnUpdate();

        builder.Property(u => u.Username)
            .IsRequired();

        builder.Property(u => u.Password)
            .IsRequired();

        builder.OwnsMany(u => u.Roles, owned =>
        {
            owned.ToTable("usuariosRoles");

            owned.WithOwner().HasForeignKey("userId");

            owned.HasKey(ur => ur.Id);

            owned.Property<long>("Id").ValueGeneratedOnAdd();

            owned.Property(ur => ur.DataCriacao)
                .IsRequired();

            owned.Property(ur => ur.DataAtualizacao)
                .ValueGeneratedOnUpdate();
            
            owned.Property(ur => ur.Role)
                .IsRequired();

        });
    }
}