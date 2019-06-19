using Balan.EventSourcing.Abstractions.Events;
using System.Collections.Generic;

namespace Balan.EventSourcing.Abstractions.Domain
{
    public interface IAggregateChangeset<TKey>
    {
        IEnumerable<IAggregateEvent<TKey>> Events { get; }
        void Commit();
    }
}
