using Balan.EventSourcing.Abstractions.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Balan.EventSourcing.Abstractions.Persistence
{
    public interface IEventStoreInitializer<TAggregate, TAggregateKey>
        where TAggregate : IAggregate<TAggregateKey>
    {
        Task EnsureCreatedAsync(CancellationToken cancellationToken = default);
    }
}
