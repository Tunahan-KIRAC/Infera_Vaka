using CorePackages.Domain.Comman;

namespace CorePackages.Domain.Entities;

public class Depot : BaseEntity
{
    public string Name { get; set; }

    // Navigation property for building
    public Building Building { get; set; }

    public ICollection<InventoryItem> InventoryItems { get; set; }
}
