using EventSourcing.Sample.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventSourcing.Sample.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiftCardController : ControllerBase
    {
        public decimal InitialCredit { get; set; } = 100;
        private readonly IGiftCardRepository _repo;
        public GiftCardController(IGiftCardRepository repo)
        {
            _repo = repo;
        }

        // GET: api/GiftCard
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GiftCard/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/GiftCard
        [HttpPost]
        public async Task Post([FromBody] RequestModel value)
        {
            var giftCard = new GiftCard(InitialCredit);
            await _repo.SaveGiftCardAsync(giftCard);
        }

        // PUT: api/GiftCard/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
