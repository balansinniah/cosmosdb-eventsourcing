using Balan.EventSourcing.Abstractions.DependencyInjection;
using Balan.EventSourcing.Abstractions.Domain;
using Balan.EventSourcing.Abstractions.Persistence;
using Balan.EventSourcing.Abstractions.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Balan.EventSourcing.Persistance.CosmosDb
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
