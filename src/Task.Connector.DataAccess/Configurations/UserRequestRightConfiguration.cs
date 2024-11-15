using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task.Connector.Domain;

namespace Task.Connector.DataAccess.Configurations;

/// <summary>
/// Конфигурация права доступа пользователя.
/// </summary>
internal class UserRequestRightConfiguration : IEntityTypeConfiguration<UserRequestRight>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<UserRequestRight> builder)
    {
        builder.ToTable("UserRequestRight");

        builder.HasKey(x => new { x.UserId, x.RightId });

        builder.HasIndex(x => new { x.UserId, x.RightId });
        builder.HasIndex(x => x.UserId);
        builder.HasIndex(x => x.RightId);

        builder.Property(x => x.UserId)
            .HasColumnType("varchar")
            .HasColumnName("userId")
            .HasMaxLength(22)
            .IsRequired();

        builder.Property(x => x.RightId)
            .HasColumnName("rightId")
            .IsRequired();
    }
}
