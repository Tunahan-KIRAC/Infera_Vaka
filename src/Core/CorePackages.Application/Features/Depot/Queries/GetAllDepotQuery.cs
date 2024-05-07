using AutoMapper;
using CorePackages.Application.Dto;
using CorePackages.Application.Interfaces.Repository;
using CorePackages.Application.Wrappers;
using MediatR;

namespace CorePackages.Application.Features.Depot.Queries;

public class GetAllDepotQuery : IRequest<ServiceResponse<List<DepotViewDto>>>
{
    public class GetAllDepotQueryHandler : IRequestHandler<GetAllDepotQuery, ServiceResponse<List<DepotViewDto>>>
    {
        private readonly IDepotRepository _DepotRepository;
        IBuildingRepository _buildingRepository;

        private readonly IMapper _mapper;

        public GetAllDepotQueryHandler(IDepotRepository DepotRepository, IMapper mapper, IBuildingRepository buildingRepository)
        {
            _DepotRepository = DepotRepository;
            _mapper = mapper;
            _buildingRepository = buildingRepository;
        }

        public async Task<ServiceResponse<List<DepotViewDto>>> Handle(GetAllDepotQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _DepotRepository.GetAllAsync(d => d.Building, d => d.InventoryItems);

                var res = _mapper.Map<List<DepotViewDto>>(data);

                return new ServiceResponse<List<DepotViewDto>>(res);
            }
            catch (Exception e)
            {

                return new ServiceResponse<List<DepotViewDto>>(message: "işlem başarısız" );
            }
        }


    }
}
