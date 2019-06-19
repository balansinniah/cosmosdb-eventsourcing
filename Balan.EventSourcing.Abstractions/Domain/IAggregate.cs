using Balan.EventSourcing.Abstractions.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Balan.EventSourcing.Abstractions.Domain
{
    public interface IAggregate<TKey>
    {
        TKey Id { get; }
        int Version { get; }
        IEnumerable<IAggregateEvent<TKey>> Events { get; }
        IAggregateChangeset<TKey> GetChangeset();
    }
}
