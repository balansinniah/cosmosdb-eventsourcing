using Balan.EventSourcing.Abstractions.Persistence;
using EventSourcing.Sample.Domain;
using System;
using System.Threading.Tasks;

namespace EventSourcing.Sample.Persistence
{
    public class GiftCardRepository : AggregateRepository<GiftCard, Guid>, IGiftCardRepository
    {
        public GiftCardRepository(IEventStore<GiftCard, Guid> eventStore)
            : base(eventStore)
        { }

        public Task SaveGiftCardAsync(GiftCard giftCard) => SaveAggregateAsync(giftCard);

        public Task<GiftCard> FindGiftCardAsync(Guid id) => FindAggregateAsync(id);

        public Task<Guid[]> GetGiftCardIdsAsync() => GetAggregateIdsAsync();
    }
}
