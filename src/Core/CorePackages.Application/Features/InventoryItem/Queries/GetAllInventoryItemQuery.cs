using AutoMapper;
using CorePackages.Application.Dto;
using CorePackages.Application.Interfaces.Repository;
using CorePackages.Application.Wrappers;
using MediatR;

namespace CorePackages.Application.Features.InventoryItem.Queries;

public class GetAllInventoryItemQuery : IRequest<ServiceResponse<List<InventoryItemViewDto>>>
{
    public class GetAllInventoryItemQueryHandler : IRequestHandler<GetAllInventoryItemQuery, ServiceResponse<List<InventoryItemViewDto>>>
    {
        private readonly IInventoryItemRepository _InventoryItemRepository;
        private readonly IMapper _mapper;

        public GetAllInventoryItemQueryHandler(IInventoryItemRepository InventoryItemRepository, IMapper mapper)
        {
            _InventoryItemRepository = InventoryItemRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<InventoryItemViewDto>>> Handle(GetAllInventoryItemQuery request, CancellationToken cancellationToken)
        {
            var data = await _InventoryItemRepository.GetAllAsync();

            var res = _mapper.Map<List<InventoryItemViewDto>>(data);

            return new ServiceResponse<List<InventoryItemViewDto>>(res);
        }


    }
}
