using Balan.EventSourcing.Abstractions.Domain;
using Balan.EventSourcing.Abstractions.Events;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Balan.EventSourcing.Abstractions.Persistence
{
    public abstract class AggregateRepository<TAggregate, TKey>
        where TAggregate : class, IAggregate<TKey>
    {
        private readonly IEventStore<TAggregate, TKey> _eventStore;

        protected AggregateRepository(IEventStore<TAggregate, TKey> eventStore)
        {
            _eventStore = eventStore;
        }

        protected async Task SaveAggregateAsync(TAggregate aggregate)
        {
            IAggregateChangeset<TKey> changeset = aggregate.GetChangeset();
            foreach (IAggregateEvent<TKey> @event in changeset.Events)
            {
                await _eventStore.AddEventAsync(@event);
                await OnEventSavedAsync(@event);
            }
            changeset.Commit();
        }

        protected virtual Task OnEventSavedAsync(IAggregateEvent<TKey> @event)
        {
            return Task.CompletedTask;
        }

        public Task<TKey[]> GetAggregateIdsAsync()
        {
            return _eventStore.GetAggregateIdsAsync();
        }

        public async Task<TAggregate> FindAggregateAsync(TKey id)
        {
            IAggregateEvent<TKey>[] events = await _eventStore.GetEventsAsync(id);
            return events.Length == 0
                ? null
                : Activator.CreateInstance(typeof(TAggregate), id, events as IEnumerable<IAggregateEvent<TKey>>) as TAggregate;
        }
    }
}
