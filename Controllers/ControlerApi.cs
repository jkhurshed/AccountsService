using Accounts.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Accounts.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControlerApi : ControllerBase
    {
        private readonly AccountDbContext _context;

        public ControlerApi(AccountDbContext context) { _context = context; }

        [HttpGet]
        public  async Task <IActionResult> Get(string number)
        {
            Account? accounts = await _context.Accounts.Where(a=>a.PhoneNumber == number).FirstOrDefaultAsync(); 
            return Ok(accounts);
        }
        [HttpPost]
        public async Task<ActionResult<Account>> Post(string _name, string SurName , string LastName , string PhoneNumber, string card)
        {
            Account newAccount = new Account()
            {  Name = _name,
                Surname = SurName,
                Lastname = LastName,
                PhoneNumber = PhoneNumber,
                Cards = card
            };

            await _context.Accounts.AddAsync(newAccount);

                await _context.SaveChangesAsync();

            return Ok(newAccount);
        }
    }
}