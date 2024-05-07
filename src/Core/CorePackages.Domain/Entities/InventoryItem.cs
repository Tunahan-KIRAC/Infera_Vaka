using CorePackages.Domain.Comman;

namespace CorePackages.Domain.Entities;

public class InventoryItem : BaseEntity
{
    public string Name { get; set; }
    public int Quantity { get; set; }

    // Foreign key for Depot
    public int DepotId { get; set; }

    // Navigation property for depot
    public Depot Depot { get; set; }

}
