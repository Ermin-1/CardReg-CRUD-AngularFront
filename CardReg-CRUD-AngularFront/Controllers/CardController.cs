using CardReg_CRUD_AngularFront.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CardReg_CRUD_AngularFront.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly CardDbContext _context;
        public CardController(CardDbContext context)
        {
            _context = context;
        }

        //get all card

        [HttpGet]
        public async Task<IActionResult> GetAllCards()
        {
            var cards = await _context.Cards.ToListAsync();
            return Ok(cards);

        }

        //get single card
        [HttpGet]
        [Route("{id:Guid}")]
        [ActionName("GetSingleCard")]
        public async Task<IActionResult> GetSingleCard([FromRoute] Guid id)
        {
            var card = await _context.Cards.FirstOrDefaultAsync(c => c.Id == id);
            if (card != null)
            {
                return Ok(card);
            }
            return NotFound("Card not found");
        }

        [HttpPost]
        public async Task<IActionResult> AddCard([FromBody] Card card)
        {
       

            card.Id = Guid.NewGuid(); // Generera ett nytt GUID för kortet
            await _context.Cards.AddAsync(card);
            await _context.SaveChangesAsync();

                return CreatedAtAction("GetSingleCard", new { id = card.Id }, card);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteCard(Guid id)
        {
            var cardToDelete = await _context.Cards.FirstOrDefaultAsync(c => c.Id == id);
            if (cardToDelete != null)
            {
                _context.Cards.Remove(cardToDelete);
                await _context.SaveChangesAsync();
                return Ok(cardToDelete);
            }

            return NotFound("Card not found");
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateCard([FromRoute] Guid id, [FromBody] Card card)
        {
            if (card == null || card.Id != id)
            {
                return BadRequest("Card data is invalid.");
            }

            var existingCard = await _context.Cards.FirstOrDefaultAsync(c => c.Id == id);
            if (existingCard == null)
            {
                return NotFound("Card not found.");
            }

            // Uppdatera kortets egenskaper
            existingCard.HolderName = card.HolderName;
            existingCard.CardNumber = card.CardNumber;
            existingCard.ExpireMonth = card.ExpireMonth;
            existingCard.ExpireYear = card.ExpireYear;
            existingCard.CVC = card.CVC;

            // Spara ändringarna i databasen
            await _context.SaveChangesAsync();

            return Ok(existingCard);
        }

    }

}

