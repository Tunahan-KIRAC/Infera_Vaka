using AutoMapper;
using CorePackages.Application.Dto;
using CorePackages.Application.Interfaces.Repository;
using CorePackages.Application.Wrappers;
using MediatR;

namespace CorePackages.Application.Features.Building.Commands;

public class CreateBuilding : IRequest<ServiceResponse<Guid>>
{

    public string Name { get; set; }

    public class CreateBuildingHandler : IRequestHandler<CreateBuilding, ServiceResponse<Guid>>
    {
        IBuildingRepository _BuildingRepository;
        private readonly IMapper mapper;

        public CreateBuildingHandler(IBuildingRepository BuildingRepository, IMapper mapper)
        {
            _BuildingRepository = BuildingRepository;
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<Guid>> Handle(CreateBuilding request, CancellationToken cancellationToken)
        {
            var data = mapper.Map<Domain.Entities.Building>(request);

            await _BuildingRepository.AddAsync(data);

            return new ServiceResponse<Guid>(data.Id);
        }
    }
}
