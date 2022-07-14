using SampleApp.Domain.Users.Handlers;
using SampleApp.Domain.Users.Repository;

namespace SampleApp.Api.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<UserCommandsHandler>();
        services.AddTransient<UserEventsHandler>();
        services.AddTransient<IUserRepository, UserRepository>();

        return services;
    }
}
