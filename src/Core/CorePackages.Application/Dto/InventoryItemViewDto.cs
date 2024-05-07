using CorePackages.Domain.Comman;

namespace CorePackages.Application.Dto;

public class InventoryItemViewDto : BaseEntity
{
    public string Name { get; set; }
    public int Quantity { get; set; }

    // Navigation property for depot
    public DepotViewDto Depot { get; set; }
}
