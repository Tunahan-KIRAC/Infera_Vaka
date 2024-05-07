using CorePackages.Domain.Comman;
using CorePackages.Domain.Entities;

namespace CorePackages.Application.Dto;

public class BuildingViewDto
{
    public string Name { get; set; }

    public ICollection<RoomViewDto> Rooms { get; set; }
    public ICollection<DepotViewDto> Depots { get; set; }
}
