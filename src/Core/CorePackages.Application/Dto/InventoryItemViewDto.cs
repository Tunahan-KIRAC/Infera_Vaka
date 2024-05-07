using CorePackages.Domain.Comman;

namespace CorePackages.Application.Dto;

public class InventoryItemViewDto 
{
    public string Name { get; set; }
    public int Quantity { get; set; }

    // Navigation property for depot

    public Guid DepotId { get; set; }

    //public DepotViewDto Depot { get; set; }
}
