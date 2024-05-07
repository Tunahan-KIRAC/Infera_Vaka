using AutoMapper;
using CorePackages.Application.Dto;
using CorePackages.Application.Interfaces.Repository;
using CorePackages.Application.Wrappers;
using MediatR;

namespace CorePackages.Application.Features.Building.Queries;

public class GetByIdBuildingQuery : IRequest<ServiceResponse<BuildingViewDto>>
{

    public Guid Id { get; set; }
    public class GetByIdBuildingQueryHandler : IRequestHandler<GetByIdBuildingQuery, ServiceResponse<BuildingViewDto>>
    {
        private readonly IBuildingRepository _BuildingRepository;
        private readonly IMapper _mapper;

        public GetByIdBuildingQueryHandler(IMapper mapper, IBuildingRepository BuildingRepository)
        {
            _mapper = mapper;
            _BuildingRepository = BuildingRepository;
        }

        public async Task<ServiceResponse<BuildingViewDto>> Handle(GetByIdBuildingQuery request, CancellationToken cancellationToken)
        {
            var data = await _BuildingRepository.GetByIdAsync(request.Id);

            var res = _mapper.Map<BuildingViewDto>(data);

            return new ServiceResponse<BuildingViewDto>(res);
        }
    }
}
