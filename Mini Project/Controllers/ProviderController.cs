using LocalServiceFinder.Models;
using LocalServiceFinder.Services;
using Microsoft.AspNetCore.Mvc;

namespace LocalServiceFinder.Controllers;

public class ProviderController : Controller
{
    private readonly ProviderService _providerService;

    public ProviderController(ProviderService providerService)
    {
        _providerService = providerService;
    }

    public async Task<IActionResult> Index(bool availableOnly = false)
    {
        var providers = availableOnly
            ? await _providerService.GetAvailableProvidersAsync()
            : await _providerService.GetAllProvidersAsync();

        ViewData["AvailableOnly"] = availableOnly;
        return View(providers);
    }

    public IActionResult Create()
    {
        return View(new Provider());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Provider provider)
    {
        if (!ModelState.IsValid)
        {
            return View(provider);
        }

        await _providerService.AddProviderAsync(provider);
        return RedirectToAction(nameof(Index));
    }
}
