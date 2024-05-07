using CorePackages.Domain.Comman;

namespace CorePackages.Application.Dto;

public class RoomViewDto:BaseEntity
{
    public string Name { get; set; }
    public BuildingViewDto Building { get; set; }
}
