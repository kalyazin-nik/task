using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task.Connector.Domain;

namespace Task.Connector.DataAccess.Configurations;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(x => x.Login);

        builder.HasIndex(x => x.Login);

        builder.Property(x => x.Login)
            .HasColumnType("varchar")
            .HasColumnName("login")
            .HasMaxLength(22)
            .IsRequired();

        builder.Property(x => x.LastName)
            .HasColumnType("varchar")
            .HasColumnName("lastName")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.FirstName)
            .HasColumnType("varchar")
            .HasColumnName("firstName")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.MiddleName)
            .HasColumnType("varchar")
            .HasColumnName("middleName")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.TelephoneNumber)
            .HasColumnType("varchar")
            .HasColumnName("telephoneNumber")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.IsLead)
            .HasColumnName("isLead")
            .IsRequired();
    }
}
