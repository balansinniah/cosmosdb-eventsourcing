using Balan.EventSourcing.Abstractions.Domain;
using Microsoft.EntityFrameworkCore;

namespace Balan.EventSourcing.Persistance.CosmosDb
{
    public interface IEventSourcingDbContext<TAggregate, TAggregateKey>
        where TAggregate : IAggregate<TAggregateKey>
    {
        DbSet<EventEntity<TAggregateKey>> GetDbSet();
    }
}
