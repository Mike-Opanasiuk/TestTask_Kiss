using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Api.Entities;
namespace Api;

public class AppDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<ImageEntity> Images { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
