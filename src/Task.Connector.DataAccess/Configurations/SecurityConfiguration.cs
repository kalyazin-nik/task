using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task.Connector.Domain;

namespace Task.Connector.DataAccess.Configurations;

/// <summary>
/// Конфигурация безопасности.
/// </summary>
internal class SecurityConfiguration : IEntityTypeConfiguration<Security>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Security> builder)
    {
        builder.ToTable("Passwords");

        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Id);
        builder.HasIndex(x => x.UserId);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .IsRequired();

        builder.Property(x => x.UserId)
            .HasColumnType("varchar")
            .HasColumnName("userId")
            .HasMaxLength(22)
            .IsRequired();

        builder.Property(x => x.Password)
            .HasColumnType("varchar")
            .HasColumnName("password")
            .HasMaxLength(20)
            .IsRequired();
    }
}
