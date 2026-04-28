using LocalServiceFinder.Data;
using LocalServiceFinder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LocalServiceFinder.Controllers;

public class ReviewController : Controller
{
    private readonly AppDbContext _context;

    public ReviewController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Create()
    {
        await PopulateProvidersAsync();
        return View(new Review { Rating = 5 });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Review review)
    {
        if (!ModelState.IsValid)
        {
            await PopulateProvidersAsync();
            return View(review);
        }

        _context.Reviews.Add(review);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index", "Home");
    }

    private async Task PopulateProvidersAsync()
    {
        var providers = await _context.Providers.ToListAsync();
        ViewData["Providers"] = new SelectList(providers, "Id", "Name");
    }
}
