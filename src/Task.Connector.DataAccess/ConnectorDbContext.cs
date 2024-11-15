using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Task.Connector.DataAccess.Configurations;
using Task.Connector.Domain;
using Task.Connector.Infrastructure.DbModels;

namespace Task.Connector.DataAccess;

/// <summary>
/// Контекст данных коннектора.
/// </summary>
public class ConnectorDbContext : DbContext
{
    private string? _schema;

    /// <summary>
    /// Представляет набор данных для ролей.
    /// </summary>
    public DbSet<ItRole> ItRoles { get; set; }

    /// <summary>
    /// Представляет набор данных для безопасности.
    /// </summary>
    public DbSet<Security> Passwords { get; set; }

    /// <summary>
    /// Представляет набор данных для прав.
    /// </summary>
    public DbSet<RequestRight> RequestRights { get; set; }

    /// <summary>
    /// Представляет набор данных для пользователей.
    /// </summary>
    public DbSet<User> Users { get; set; }

    /// <summary>
    /// Представляет набор данных для связи между пользователями и ролями.
    /// </summary>
    public DbSet<UserItRole> UsersItRoles { get; set; }

    /// <summary>
    /// Представляет набор данных для связи между пользователями и правами.
    /// </summary>
    public DbSet<UserRequestRight> UserRequestRights { get; set; }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="ConnectorDbContext"/>.
    /// </summary>
    /// <param name="options">Параметры, которые будут использоваться <see cref="DbContext"/>.</param>
    /// <param name="dbSchema">Схема контекста данных.</param>
    public ConnectorDbContext(DbContextOptions options, IOptions<DbSchema> dbSchema) : base(options)
    {
        _schema = dbSchema.Value?.Name;
    }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(_schema);

        modelBuilder.Entity<User>().HasOne(u => u.Security).WithOne(s => s.User).HasForeignKey<Security>(s => s.UserId);
        modelBuilder.Entity<User>().HasMany(u => u.UserItRoles).WithOne(uir => uir.User).HasForeignKey(uir => uir.UserId);
        modelBuilder.Entity<User>().HasMany(u => u.UserRequestRights).WithOne(urr => urr.User).HasForeignKey(urr => urr.UserId);
        modelBuilder.Entity<UserItRole>().HasOne(uir => uir.ItRole).WithMany(ir => ir.UserItRoles).HasForeignKey(uir => uir.RoleId);
        modelBuilder.Entity<UserRequestRight>().HasOne(urr => urr.RequestRight).WithMany(rr => rr.UserRequestRights).HasForeignKey(urr => urr.RightId);

        modelBuilder.ApplyConfiguration(new ItRoleConfiguration());
        modelBuilder.ApplyConfiguration(new SecurityConfiguration());
        modelBuilder.ApplyConfiguration(new RequestRightConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new UserItRoleConfiguration());
        modelBuilder.ApplyConfiguration(new UserRequestRightConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
