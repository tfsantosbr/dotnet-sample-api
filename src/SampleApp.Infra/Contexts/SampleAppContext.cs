using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace SampleApp.Infra.Contexts;

public class SampleAppContext : DbContext
{
    public SampleAppContext(DbContextOptions<SampleAppContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
