namespace HomesteadManagerApi.Data;

using HomesteadManager.Shared.Models;
using Microsoft.EntityFrameworkCore;

public class HomesteadContext : DbContext
{
    public HomesteadContext(DbContextOptions<HomesteadContext> options) : base(options)
    {
    }

    public DbSet<Homestead> Homesteads { get; set; } = null!;
}
