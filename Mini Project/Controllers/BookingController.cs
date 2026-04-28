using LocalServiceFinder.Data;
using LocalServiceFinder.Models;
using LocalServiceFinder.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LocalServiceFinder.Controllers;

public class BookingController : Controller
{
    private readonly BookingService _bookingService;
    private readonly AppDbContext _context;
    private readonly ILogger<BookingController> _logger;

    public BookingController(BookingService bookingService, AppDbContext context, ILogger<BookingController> logger)
    {
        _bookingService = bookingService;
        _context = context;
        _logger = logger;
    }

    public async Task<IActionResult> Create()
    {
        await PopulateSelectionsAsync();
        return View(new Booking { Date = DateTime.Today });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Booking booking)
    {
        if (!ModelState.IsValid)
        {
            await PopulateSelectionsAsync();
            return View(booking);
        }

        await _bookingService.AddBookingAsync(booking);
        _logger.LogInformation("New booking created for provider {ProviderId} by user {UserId} on {Date}.", booking.ProviderId, booking.UserId, booking.Date);
        return RedirectToAction("Index", "Home");
    }

    private async Task PopulateSelectionsAsync()
    {
        var users = await _bookingService.GetAllUsersAsync();
        var providers = await _context.Providers.ToListAsync();

        ViewData["Users"] = new SelectList(users, "Id", "Name");
        ViewData["Providers"] = new SelectList(providers, "Id", "Name");
    }
}
