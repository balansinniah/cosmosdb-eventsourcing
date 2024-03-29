﻿using System;

namespace Balan.EventSourcing.Persistance.CosmosDb
{
    public class EventEntity<TAggregateKey>
    {
        public TAggregateKey AggregateId { get; set; }
        public int AggregateVersion { get; set; }
        public DateTime Timestamp { get; set; }
        public string Serialized { get; set; }
    }
}
