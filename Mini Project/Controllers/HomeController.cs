using System.Diagnostics;
using LocalServiceFinder.Data;
using LocalServiceFinder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace LocalServiceFinder.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;
    private readonly IMemoryCache _cache;

    public HomeController(AppDbContext context, IMemoryCache cache)
    {
        _context = context;
        _cache = cache;
    }

    public async Task<IActionResult> Index(bool availableOnly = false)
    {
        var providers = await _cache.GetOrCreateAsync("ProviderList", async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30);
            return await _context.Providers.ToListAsync();
        }) ?? new List<Provider>();

        var model = availableOnly ? providers.Where(p => p.IsAvailable).ToList() : providers.ToList();
        ViewData["AvailableOnly"] = availableOnly;
        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
