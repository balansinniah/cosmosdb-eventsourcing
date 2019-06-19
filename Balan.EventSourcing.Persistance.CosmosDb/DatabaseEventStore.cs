using Balan.EventSourcing.Abstractions.Domain;
using Balan.EventSourcing.Abstractions.Events;
using Balan.EventSourcing.Abstractions.Persistence;
using Balan.EventSourcing.Abstractions.Serialization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Balan.EventSourcing.Persistance.CosmosDb
{
    public class DatabaseEventStore<TDbContext, TAggregate, TAggregateKey> : IEventStore<TAggregate, TAggregateKey>
        where TDbContext : DbContext, IEventSourcingDbContext<TAggregate, TAggregateKey>
        where TAggregate : IAggregate<TAggregateKey>
    {
        private readonly TDbContext _context;
        private readonly IObjectSerializer<IAggregateEvent<TAggregateKey>> _eventSerializer;

        public DatabaseEventStore(TDbContext context,IObjectSerializer<IAggregateEvent<TAggregateKey>> eventSerializer)
        {
            _context            = context;
            _eventSerializer    = eventSerializer;
        }

        public async Task AddEventAsync(IAggregateEvent<TAggregateKey> @event,CancellationToken cancellationToken = default)
        {
            var serialized          = _eventSerializer.Serialize(@event);
            var entity              = new EventEntity<TAggregateKey>
            {
                AggregateId         = @event.AggregateId,
                AggregateVersion    = @event.AggregateVersion,
                Timestamp           = @event.Timestamp,
                Serialized          = serialized
            };
            await _context.GetDbSet().AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public Task<TAggregateKey[]> GetAggregateIdsAsync(
            CancellationToken cancellationToken = default)
        {
            return _context.GetDbSet()
                .Select(x => x.AggregateId)
                .Distinct()
                .ToArrayAsync(cancellationToken);
        }

        public async Task<IAggregateEvent<TAggregateKey>[]> GetEventsAsync(TAggregateKey aggregateId,
            CancellationToken cancellationToken = default)
        {
            List<string> serializedEvents = await _context.GetDbSet()
                .Where(x => x.AggregateId.Equals(aggregateId))
                .OrderBy(x => x.AggregateVersion)
                .Select(x => x.Serialized)
                .ToListAsync(cancellationToken);

            return serializedEvents
                .Select(x => _eventSerializer.Deserialize(x))
                .ToArray();
        }
    }
}
