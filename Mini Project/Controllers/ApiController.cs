using LocalServiceFinder.Data;
using LocalServiceFinder.Models;
using LocalServiceFinder.Services;
using Microsoft.AspNetCore.Mvc;

namespace LocalServiceFinder.Controllers;

[ApiController]
[Route("api")]
public class ApiController : ControllerBase
{
    private readonly ProviderService _providerService;
    private readonly BookingService _bookingService;

    public ApiController(ProviderService providerService, BookingService bookingService)
    {
        _providerService = providerService;
        _bookingService = bookingService;
    }

    [HttpGet("providers")]
    public async Task<IActionResult> GetProviders()
    {
        var providers = await _providerService.GetAllProvidersAsync();
        return Ok(providers);
    }

    [HttpPost("bookings")]
    public async Task<IActionResult> CreateBooking([FromBody] Booking booking)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _bookingService.AddBookingAsync(booking);
        return CreatedAtAction(null, new { id = booking.Id }, booking);
    }
}
