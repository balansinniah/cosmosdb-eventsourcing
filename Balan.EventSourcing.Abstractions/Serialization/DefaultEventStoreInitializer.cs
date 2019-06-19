using Balan.EventSourcing.Abstractions.Domain;
using Balan.EventSourcing.Abstractions.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Balan.EventSourcing.Abstractions.Serialization
{
    public class DefaultEventStoreInitializer<TAggregate, TAggregateKey> : IEventStoreInitializer<TAggregate, TAggregateKey>
        where TAggregate : IAggregate<TAggregateKey>
    {
        public Task EnsureCreatedAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;
    }
}
