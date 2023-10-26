using Microsoft.EntityFrameworkCore;
using SampleApp.Infra.Contexts;

namespace SampleApp.Api.Extensions;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
    {
        // contexts

        services.AddDbContext<SampleAppContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"))
        );

        return services;
    }

    public static void MigrateAndSeedData(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<SampleAppContext>();

            context.Database.Migrate();
        }
    }
}
