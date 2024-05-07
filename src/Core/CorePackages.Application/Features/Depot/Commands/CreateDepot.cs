using AutoMapper;
using CorePackages.Application.Interfaces.Repository;
using CorePackages.Application.Wrappers;
using MediatR;

namespace CorePackages.Application.Features.Depot.Commands;

public class CreateDepot : IRequest<ServiceResponse<Guid>>
{
    public string Name { get; set; }

    public Guid BuildingId { get; set; }
    public class CreateDepotHandler : IRequestHandler<CreateDepot, ServiceResponse<Guid>>
    {
        IDepotRepository _DepotRepository;
        IBuildingRepository _buildingRepository;
        private readonly IMapper mapper;

        public CreateDepotHandler(IDepotRepository DepotRepository, IMapper mapper, IBuildingRepository buildingRepository)
        {
            _DepotRepository = DepotRepository;
            this.mapper = mapper;
            _buildingRepository = buildingRepository;
        }

        public async Task<ServiceResponse<Guid>> Handle(CreateDepot request, CancellationToken cancellationToken)
        {
            // Map the request object to Depot entity
            var depotEntity = mapper.Map<Domain.Entities.Depot>(request);

            // Check if BuildingId is provided
            if (request.BuildingId != Guid.Empty)
            {
                // Get the building by its id
                var building = await _buildingRepository.GetByIdAsync(request.BuildingId);

                // Check if the building exists
                if (building != null)
                {
                    // Set the Building property of the depot entity
                    depotEntity.Building = building;

                }
                else
                {
                    // Handle the case where the building does not exist
                    // Return an appropriate response indicating failure
                    return new ServiceResponse<Guid>(message : "The specified building does not exist.");
                }
            }

            // Add the depot to the repository
            await _DepotRepository.AddAsync(depotEntity);

            // Return a success response with the newly created depot Id
            return new ServiceResponse<Guid>(depotEntity.Id);
        }

    }
}
