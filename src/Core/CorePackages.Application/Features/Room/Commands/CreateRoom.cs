using AutoMapper;
using CorePackages.Application.Interfaces.Repository;
using CorePackages.Application.Wrappers;
using MediatR;

namespace CorePackages.Application.Features.Room.Commands;

public class CreateRoom : IRequest<ServiceResponse<Guid>>
{

    public string Name { get; set; }

    public Guid BuildingId { get; set; }
    public class CreateRoomHandler : IRequestHandler<CreateRoom, ServiceResponse<Guid>>
    {
        IRoomRepository _RoomRepository;
        IBuildingRepository _buildingRepository;
        private readonly IMapper mapper;

        public CreateRoomHandler(IRoomRepository RoomRepository, IMapper mapper, IBuildingRepository buildingRepository)
        {
            _RoomRepository = RoomRepository;
            this.mapper = mapper;
            _buildingRepository = buildingRepository;
        }

        public async Task<ServiceResponse<Guid>> Handle(CreateRoom request, CancellationToken cancellationToken)
        {
            // Map the request object to Room entity
            var RoomEntity = mapper.Map<Domain.Entities.Room>(request);

            // Check if BuildingId is provided
            if (request.BuildingId != Guid.Empty)
            {
                // Get the building by its id
                var building = await _buildingRepository.GetByIdAsync(request.BuildingId);

                // Check if the building exists
                if (building != null)
                {
                    // Set the Building property of the Room entity
                    RoomEntity.Building = building;
                }
                else
                {
                    // Handle the case where the building does not exist
                    // Return an appropriate response indicating failure
                    return new ServiceResponse<Guid>(message: "The specified romm does not exist.");
                }
            }

            // Add the Room to the repository
            await _RoomRepository.AddAsync(RoomEntity);

            // Return a success response with the newly created Room Id
            return new ServiceResponse<Guid>(RoomEntity.Id);
        }

    }
}
