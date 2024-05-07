using CorePackages.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CorePackeges.Persistence.Context;

public class ApplicationDbContext : DbContext
{
    public DbSet<Building> Buildings { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Depot> Depots { get; set; }
    public DbSet<InventoryItem> InventoryItems { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
    {
    }

}
