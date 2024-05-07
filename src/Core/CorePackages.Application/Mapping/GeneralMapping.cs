using AutoMapper;
using CorePackages.Application.Dto;
using CorePackages.Application.Features.Building.Commands;
using CorePackages.Application.Features.Depot.Commands;
using CorePackages.Application.Features.InventoryItem.Commands;
using CorePackages.Application.Features.Room.Commands;

namespace CorePackages.Application.Mapping;

public class GeneralMapping : Profile
{

    public GeneralMapping()
    {
        CreateMap<Domain.Entities.Building, BuildingViewDto>().ReverseMap();
        CreateMap<Domain.Entities.Building, CreateBuilding>().ReverseMap();

        CreateMap<Domain.Entities.Depot, DepotViewDto>().ReverseMap();
        CreateMap<Domain.Entities.Depot, CreateDepot>().ReverseMap();

        CreateMap<Domain.Entities.InventoryItem, InventoryItemViewDto>().ReverseMap();
        CreateMap<Domain.Entities.InventoryItem, CreateInventoryItem>().ReverseMap();

        CreateMap<Domain.Entities.Room, RoomViewDto>().ReverseMap();
        CreateMap<Domain.Entities.Room, CreateRoom>().ReverseMap();

    }

}
