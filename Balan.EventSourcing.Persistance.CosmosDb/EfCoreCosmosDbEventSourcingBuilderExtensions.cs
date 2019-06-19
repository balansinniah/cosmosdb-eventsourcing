using Balan.EventSourcing.Abstractions.DependencyInjection;
using Balan.EventSourcing.Abstractions.Domain;
using Balan.EventSourcing.Abstractions.Persistence;
using Balan.EventSourcing.Abstractions.Serialization;
using Balan.EventSourcing.Persistance.CosmosDb;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class EfCoreCosmosDbEventSourcingBuilderExtensions
    {
        public static IEventSourcingBuilder UseCosmosDbEventStore<TEventSourcingDbContext, TAggregate, TAggregateKey>(
           this IEventSourcingBuilder builder)
           where TEventSourcingDbContext : DbContext, IEventSourcingDbContext<TAggregate, TAggregateKey>
           where TAggregate : IAggregate<TAggregateKey>
        {
            builder.Services
                .AddScoped<IEventStore<TAggregate, TAggregateKey>, DatabaseEventStore<TEventSourcingDbContext, TAggregate, TAggregateKey>>()
                .AddScoped<IEventStoreInitializer<TAggregate, TAggregateKey>, DefaultEventStoreInitializer<TAggregate, TAggregateKey>>()
                ;
            return builder;
        }
    }
}
