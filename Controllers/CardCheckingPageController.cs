using Accounts.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Controllers;

[ApiController]
[Route("api/card")]
public class CardCheckingPageController(AccountDbContext context) : Controller
{
    [HttpGet("cardCheckingPage")]

    public IActionResult CardChecking()
    {
        return View("~/Views/Cards/CardChecking.cshtml");
    }
}