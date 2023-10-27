using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SampleApp.Domain.Entities;

namespace SampleApp.Infra.Contexts;

public class SampleAppContext : DbContext
{
    public SampleAppContext(DbContextOptions<SampleAppContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
