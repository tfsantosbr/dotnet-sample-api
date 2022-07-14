using Microsoft.Extensions.DependencyInjection;
using SampleApp.Shared.Notifications.Interfaces;
using SampleApp.Shared.Notifications.Services;

namespace SampleApp.Shared.Notifications.AspNet
{
    public static class NotificationsServicesExtension
    {
        public static IServiceCollection AddNotifications(this IServiceCollection services)
        {
            services.AddScoped<INotifier, Notifier>();

            return services;
        }
    }
}
