using AutoMapper;
using CorePackages.Application.Interfaces.Repository;
using CorePackages.Application.Wrappers;
using MediatR;

namespace CorePackages.Application.Features.InventoryItem.Commands;

public class CreateInventoryItem : IRequest<ServiceResponse<Guid>>
{
    public string Name { get; set; }
    public int Quantity { get; set; }

    public class CreateInventoryItemHandler : IRequestHandler<CreateInventoryItem, ServiceResponse<Guid>>
    {
        IInventoryItemRepository _InventoryItemRepository;
        private readonly IMapper mapper;

        public CreateInventoryItemHandler(IInventoryItemRepository InventoryItemRepository, IMapper mapper)
        {
            _InventoryItemRepository = InventoryItemRepository;
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<Guid>> Handle(CreateInventoryItem request, CancellationToken cancellationToken)
        {
            var data = mapper.Map<Domain.Entities.InventoryItem>(request);

            await _InventoryItemRepository.AddAsync(data);

            return new ServiceResponse<Guid>(data.Id);
        }
    }
}
