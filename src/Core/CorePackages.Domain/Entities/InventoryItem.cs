using CorePackages.Domain.Comman;

namespace CorePackages.Domain.Entities;

public class InventoryItem : BaseEntity
{
    public string Name { get; set; }
    public int Quantity { get; set; }

    public Guid DepotId { get; set; }
    public ICollection<Depot> Depots { get; set; }
}
