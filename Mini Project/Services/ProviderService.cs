using LocalServiceFinder.Data;
using LocalServiceFinder.Models;
using Microsoft.EntityFrameworkCore;

namespace LocalServiceFinder.Services;

public class ProviderService
{
    private readonly AppDbContext _context;

    public ProviderService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Provider>> GetAllProvidersAsync()
    {
        return await _context.Providers.ToListAsync();
    }

    public async Task<List<Provider>> GetAvailableProvidersAsync()
    {
        return await _context.Providers.Where(p => p.IsAvailable).ToListAsync();
    }

    public async Task AddProviderAsync(Provider provider)
    {
        _context.Providers.Add(provider);
        await _context.SaveChangesAsync();
    }
}
