using AutoMapper;
using CorePackages.Application.Dto;
using CorePackages.Application.Interfaces.Repository;
using CorePackages.Application.Wrappers;
using MediatR;

namespace CorePackages.Application.Features.Depot.Queries;

public class GetByIdDepotQuery : IRequest<ServiceResponse<DepotViewDto>>
{
    public Guid Id { get; set; }
    public class GetByIdDepotQueryHandler : IRequestHandler<GetByIdDepotQuery, ServiceResponse<DepotViewDto>>
    {
        private readonly IDepotRepository _DepotRepository;
        private readonly IMapper _mapper;

        public GetByIdDepotQueryHandler(IMapper mapper, IDepotRepository DepotRepository)
        {
            _mapper = mapper;
            _DepotRepository = DepotRepository;
        }

        public async Task<ServiceResponse<DepotViewDto>> Handle(GetByIdDepotQuery request, CancellationToken cancellationToken)
        {
            var data = await _DepotRepository.GetByIdAsync(request.Id, d => d.Building, d => d.InventoryItems);


            var res = _mapper.Map<DepotViewDto>(data);

            return new ServiceResponse<DepotViewDto>(res);
        }
    }
}
