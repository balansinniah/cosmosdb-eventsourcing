using Balan.EventSourcing.Abstractions.DependencyInjection;
using Balan.EventSourcing.Serialization.Json;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Balan.EventSourcing
{
    public static class EventSourcingServiceCollectionExtensions
    {
        public static IServiceCollection AddEventSourcing(this IServiceCollection services, Action<IEventSourcingBuilder> setupAction)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            IEventSourcingBuilder builder = new EventSourcingBuilder(services)
                .UseJsonEventSerializer();

            setupAction?.Invoke(builder);

            return services;
        }
    }
}
