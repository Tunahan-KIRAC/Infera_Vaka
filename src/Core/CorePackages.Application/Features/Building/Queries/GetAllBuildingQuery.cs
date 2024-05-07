using AutoMapper;
using CorePackages.Application.Dto;
using CorePackages.Application.Interfaces.Repository;
using CorePackages.Application.Wrappers;
using MediatR;

namespace CorePackages.Application.Features.Building.Queries;

public class GetAllBuildingQuery : IRequest<ServiceResponse<List<BuildingViewDto>>>
{
    public class GetAllBuildingQueryHandler : IRequestHandler<GetAllBuildingQuery, ServiceResponse<List<BuildingViewDto>>>
    {
        private readonly IBuildingRepository _BuildingRepository;
        private readonly IMapper _mapper;

        public GetAllBuildingQueryHandler(IBuildingRepository BuildingRepository, IMapper mapper)
        {
            _BuildingRepository = BuildingRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<BuildingViewDto>>> Handle(GetAllBuildingQuery request, CancellationToken cancellationToken)
        {
            var data = await _BuildingRepository.GetAllAsync();

            var res = _mapper.Map<List<BuildingViewDto>>(data);

            return new ServiceResponse<List<BuildingViewDto>>(res);
        }


    }
}
