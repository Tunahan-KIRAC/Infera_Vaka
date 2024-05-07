using AutoMapper;
using CorePackages.Application.Dto;
using CorePackages.Application.Interfaces.Repository;
using CorePackages.Application.Wrappers;
using MediatR;

namespace CorePackages.Application.Features.InventoryItem.Queries;

public class GetByIdInventoryItemQuery : IRequest<ServiceResponse<InventoryItemViewDto>>
{
    public Guid Id { get; set; }
    public class GetByIdInventoryItemQueryHandler : IRequestHandler<GetByIdInventoryItemQuery, ServiceResponse<InventoryItemViewDto>>
    {
        private readonly IInventoryItemRepository _InventoryItemRepository;
        private readonly IMapper _mapper;

        public GetByIdInventoryItemQueryHandler(IMapper mapper, IInventoryItemRepository InventoryItemRepository)
        {
            _mapper = mapper;
            _InventoryItemRepository = InventoryItemRepository;
        }

        public async Task<ServiceResponse<InventoryItemViewDto>> Handle(GetByIdInventoryItemQuery request, CancellationToken cancellationToken)
        {
            var data = await _InventoryItemRepository.GetByIdAsync(request.Id);

            var res = _mapper.Map<InventoryItemViewDto>(data);

            return new ServiceResponse<InventoryItemViewDto>(res);
        }
    }
}
