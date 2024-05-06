namespace HomesteadManagerApi.Data;

using Microsoft.EntityFrameworkCore;
using HomesteadManagerApi.Models;

public class HomesteadContext : DbContext
{
    public HomesteadContext(DbContextOptions<HomesteadContext> options) : base(options)
    {
    }

    public DbSet<Homestead> Homesteads { get; set; } = null!;
}
