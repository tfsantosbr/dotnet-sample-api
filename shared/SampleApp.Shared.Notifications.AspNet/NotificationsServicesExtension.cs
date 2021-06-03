using Microsoft.Extensions.DependencyInjection;
using SampleApp.Shared.Notifications.Interfaces;
using SampleApp.Shared.Notifications.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
