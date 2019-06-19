using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Sample.Domain
{
    public interface IGiftCardRepository
    {
        Task SaveGiftCardAsync(GiftCard giftCard);
        Task<GiftCard> FindGiftCardAsync(Guid id);
        Task<Guid[]> GetGiftCardIdsAsync();
    }
}
