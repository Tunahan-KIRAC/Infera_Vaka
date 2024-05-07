using AutoMapper;
using CorePackages.Application.Dto;
using CorePackages.Application.Interfaces.Repository;
using CorePackages.Application.Wrappers;
using MediatR;

namespace CorePackages.Application.Features.Room.Queries;

public class GetByIdRoomQuery : IRequest<ServiceResponse<RoomViewDto>>
{
    public Guid Id { get; set; }
    public class GetByIdRoomQueryHandler : IRequestHandler<GetByIdRoomQuery, ServiceResponse<RoomViewDto>>
    {
        private readonly IRoomRepository _RoomRepository;
        private readonly IMapper _mapper;

        public GetByIdRoomQueryHandler(IMapper mapper, IRoomRepository RoomRepository)
        {
            _mapper = mapper;
            _RoomRepository = RoomRepository;
        }

        public async Task<ServiceResponse<RoomViewDto>> Handle(GetByIdRoomQuery request, CancellationToken cancellationToken)
        {
            var data = await _RoomRepository.GetByIdAsync(request.Id, d => d.Building);


            var res = _mapper.Map<RoomViewDto>(data);

            return new ServiceResponse<RoomViewDto>(res);
        }
    }
}
