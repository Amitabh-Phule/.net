using System.ComponentModel.DataAnnotations;

namespace LocalServiceFinder.Models;

public class Booking
{
    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public int ProviderId { get; set; }

    [Required]
    public DateTime Date { get; set; } = DateTime.Today;

    public User? User { get; set; }
    public Provider? Provider { get; set; }
}
