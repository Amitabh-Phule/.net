using System.ComponentModel.DataAnnotations;

namespace LocalServiceFinder.Models;

public class Provider
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string ServiceType { get; set; } = string.Empty;

    public bool IsAvailable { get; set; } = true;

    public ICollection<Booking>? Bookings { get; set; }
    public ICollection<Review>? Reviews { get; set; }
}
