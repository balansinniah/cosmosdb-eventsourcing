using Balan.EventSourcing.Abstractions.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventSourcing.Sample.Events
{
    public class GiftCardDebited : AggregateEvent<Guid>
    {
        public GiftCardDebited(Guid aggregateId, int aggregateVersion, DateTime timestamp, decimal amount)
            : base(aggregateId, aggregateVersion, timestamp)
        {
            Amount = amount;
        }

        public decimal Amount { get; }

        public override string ToString() => $"{Amount:0.00} € debited.";
    }
}
