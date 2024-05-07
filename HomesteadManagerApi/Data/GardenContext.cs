namespace HomesteadManagerApi.Data;

using HomesteadManager.Shared.Models;
using Microsoft.EntityFrameworkCore;

public class GardenContext : DbContext
{
    public GardenContext(DbContextOptions<GardenContext> options) : base(options)
    {
    }

    public DbSet<Garden> Gardens { get; set; } = null!;
}
