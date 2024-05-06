namespace HomesteadManagerApi.Data;

using Microsoft.EntityFrameworkCore;
using HomesteadManagerApi.Models;

public class PlantContext : DbContext
{
    public PlantContext(DbContextOptions<PlantContext> options) : base(options)
    {
    }

    public DbSet<Plant> Plants { get; set; } = null!;
}
