using Balan.EventSourcing.Persistance.CosmosDb;
using EventSourcing.Sample.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace EventSourcing.Sample.Web.Api
{
    public class SampleDbContext : DbContext, IEventSourcingDbContext<GiftCard, Guid>
    {
        public SampleDbContext(DbContextOptions<SampleDbContext> options)
            : base(options)
        { }

        public DbSet<EventEntity<Guid>> GiftCardEvents { get; set; }


        DbSet<EventEntity<Guid>> IEventSourcingDbContext<GiftCard, Guid>.GetDbSet()
            => GiftCardEvents;
    }
}
