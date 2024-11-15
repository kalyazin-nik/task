﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task.Connector.Domain;

namespace Task.Connector.DataAccess.Configurations;

/// <summary>
/// Конфигурация роли пользователя.
/// </summary>
internal class UserItRoleConfiguration : IEntityTypeConfiguration<UserItRole>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<UserItRole> builder)
    {
        builder.ToTable("UserITRole");

        builder.HasKey(x => new { x.UserId, x.RoleId });

        builder.HasIndex(x => new { x.UserId, x.RoleId });
        builder.HasIndex(x => x.UserId);
        builder.HasIndex(x => x.RoleId);

        builder.Property(x => x.UserId)
            .HasColumnType("varchar")
            .HasColumnName("userId")
            .HasMaxLength(22)
            .IsRequired();

        builder.Property(x => x.RoleId)
            .HasColumnName("roleId")
            .IsRequired();
    }
}
