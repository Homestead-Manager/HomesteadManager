namespace HomesteadManagerApi.Data;

using HomesteadManager.Shared.Models;
using Microsoft.EntityFrameworkCore;

public class BedContext : DbContext
{
    public BedContext(DbContextOptions<BedContext> options) : base(options)
    {
    }

    public DbSet<Bed> Beds { get; set; } = null!;
}
