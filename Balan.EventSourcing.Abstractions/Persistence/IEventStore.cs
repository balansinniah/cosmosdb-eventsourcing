using Balan.EventSourcing.Abstractions.Domain;
using Balan.EventSourcing.Abstractions.Events;
using System.Threading;
using System.Threading.Tasks;

namespace Balan.EventSourcing.Abstractions.Persistence
{
    public interface IEventStore<TAggregate, TAggregateKey> where TAggregate : IAggregate<TAggregateKey>
    {
        Task AddEventAsync(IAggregateEvent<TAggregateKey> @event, CancellationToken cancellationToken = default);
        Task<IAggregateEvent<TAggregateKey>[]> GetEventsAsync(TAggregateKey aggregateId, CancellationToken cancellationToken = default);
        Task<TAggregateKey[]> GetAggregateIdsAsync(CancellationToken cancellationToken = default);
    }
}
