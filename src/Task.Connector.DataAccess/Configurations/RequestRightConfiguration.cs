using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task.Connector.Domain;

namespace Task.Connector.DataAccess.Configurations;

/// <summary>
/// Конфигурация права доступа.
/// </summary>
internal class RequestRightConfiguration : IEntityTypeConfiguration<RequestRight>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<RequestRight> builder)
    {
        builder.ToTable("RequestRight");

        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .IsRequired();

        builder.Property(x => x.Name)
            .HasColumnType("text")
            .HasColumnName("name")
            .IsRequired();
    }
}
