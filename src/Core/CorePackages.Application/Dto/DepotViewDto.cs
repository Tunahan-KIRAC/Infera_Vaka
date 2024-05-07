using CorePackages.Domain.Comman;

namespace CorePackages.Application.Dto;

public class DepotViewDto:BaseEntity
{
    public string Name { get; set; }
    public BuildingViewDto Building { get; set; }
    public ICollection<InventoryItemViewDto> InventoryItems { get; set; }
}
