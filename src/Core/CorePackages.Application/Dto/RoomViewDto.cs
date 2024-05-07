using CorePackages.Domain.Comman;

namespace CorePackages.Application.Dto;

public class RoomViewDto
{
    public string Name { get; set; }

    public Guid BuildingId { get; set; }

    public BuildingViewDto Building { get; set; }
}
