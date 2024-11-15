using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Task.Connector.DataAccess.Configurations;
using Task.Connector.Domain;
using Task.Connector.Infrastructure.DbModels;

namespace Task.Connector.DataAccess;

public class ConnectorDbContext : DbContext
{
    private string? _schema;

    public DbSet<ItRole> ItRoles { get; set; }
    public DbSet<Security> Passwords { get; set; }
    public DbSet<RequestRight> RequestRights { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserItRole> UsersItRoles { get; set; }
    public DbSet<UserRequestRight> UserRequestRights { get; set; }

    public ConnectorDbContext(DbContextOptions options, IOptions<DbSchema> dbSchema) : base(options)
    {
        _schema = dbSchema.Value?.Name;
    }

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
