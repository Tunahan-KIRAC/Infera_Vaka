using CorePackages.Domain.Comman;

namespace CorePackages.Application.Dto;

public class DepotViewDto
{
    public string Name { get; set; }
    public Guid BuildingId { get; set; }
    //public BuildingViewDto Building { get; set; }
    public List<InventoryItemViewDto> InventoryItems { get; set; }
}
