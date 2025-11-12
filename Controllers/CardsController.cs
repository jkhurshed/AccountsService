using Accounts.Entities;

namespace Accounts.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class CardsController : ControllerBase
{
    private readonly AccountDbContext _context;

    public CardsController(AccountDbContext context)
    {
        _context = context;
    }

    // GET: api/cards
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Card>>> GetCards()
    {
        var cards = await _context.Cards.ToListAsync();
        return Ok(cards);
    }

    // GET: api/cards/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Card>> GetCard(int id)
    {
        var card = await _context.Cards.FindAsync(id);
        if (card == null)
            return NotFound();

        return Ok(card);
    }
    
    [HttpGet("by-pan/{panNumber}")]
    public async Task<ActionResult<Card>> GetCardByPan(string panNumber)
    {
        // Look up the card by PanNumber (case-insensitive)
        var card = await _context.Cards
            .FirstOrDefaultAsync(c => c.PanNumber == panNumber);

        if (card == null)
            return NotFound(new { message = "Card not found for the given PAN number." });

        return Ok(card);
    }

    // POST: api/cards
    [HttpPost]
    public async Task<ActionResult<Card>> PostCard(Card card)
    {
        _context.Cards.Add(card);
        await _context.SaveChangesAsync();

        // Returns 201 Created + location header
        return CreatedAtAction(nameof(GetCard), new { id = card.Id }, card);
    }
    
    // Card check by cardNumber, expirationDate, cvv and CardHolder
    [HttpGet("cardCheckForExisting")]
    public async Task<ActionResult<Card>> CardChecking(
        string cardNumber, int expMonth, int expYear, 
        int cvv, string cardHolder)
    {
        var isCardValid = await _context.Cards
            .Select(c => new { c.Id, c.PanNumber, c.ExpMonth, c.ExpYear, c.Cvv, c.CardHolder })
            .Where(c => 
                c.PanNumber == cardNumber && 
                c.ExpMonth == expMonth && 
                c.ExpYear == expYear && 
                c.Cvv == cvv && 
                c.CardHolder == cardHolder)
            .FirstOrDefaultAsync();
        return Ok(isCardValid);
    }
}
