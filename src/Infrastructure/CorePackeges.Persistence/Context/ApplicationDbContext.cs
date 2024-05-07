using CorePackages.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CorePackeges.Persistence.Context;

public class ApplicationDbContext : DbContext
{

    public DbSet<Configuration> Configurations { get; set; }
    public DbSet<Building> Buildings { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Depot> Depots { get; set; }
    public DbSet<InventoryItem> InventoryItems { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure entities
        //modelBuilder.ApplyConfiguration(new BuildingConfiguration());
        //modelBuilder.ApplyConfiguration(new RoomConfiguration());
        //modelBuilder.ApplyConfiguration(new DepotConfiguration());
        //modelBuilder.ApplyConfiguration(new InventoryItemConfiguration());
        //modelBuilder.ApplyConfiguration(new DepotEntryConfiguration());
        //modelBuilder.ApplyConfiguration(new DepotExitConfiguration());

    }



}
