using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleApp.Domain.Entities;

namespace SampleApp.Infra.Contexts.Configurations;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users").HasKey(p => p.Id);

        builder.OwnsOne(p => p.CompleteName, completeName =>
        {
            completeName.Property(p => p.FirstName)
                .HasColumnName("FirstName").IsRequired().HasMaxLength(150);

            completeName.Property(p => p.LastName)
                .HasColumnName("LastName").IsRequired().HasMaxLength(150);
        });

        builder.OwnsOne(p => p.Email, email =>
        {
            email.Property(p => p.Address)
                .HasColumnName("Email").IsRequired().HasMaxLength(300);

            email.HasIndex(p => p.Address)
                .IsUnique();
        });

        builder.OwnsOne(p => p.Password, password =>
        {
            password.Property(p => p.Value)
                .HasColumnName("Password").IsRequired().HasMaxLength(300);
        });
    }
}
