using System;
using System.Collections.Generic;
using System.Text;

namespace Balan.EventSourcing.Abstractions.Events
{
    public interface IAggregateEvent<TAggregateKey>
    {
        // ID of domain aggregate
        TAggregateKey AggregateId { get; }

        // Version of domain aggregate after event occurred
        int AggregateVersion { get; }

        // Timestamp of event
        DateTime Timestamp { get; }
    }
}
