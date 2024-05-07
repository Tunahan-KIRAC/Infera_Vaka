using AutoMapper;
using CorePackages.Application.Dto;
using CorePackages.Application.Interfaces.Repository;
using CorePackages.Application.Wrappers;
using MediatR;

namespace CorePackages.Application.Features.Room.Queries;

public class GetAllRoomQuery : IRequest<ServiceResponse<List<RoomViewDto>>>
{
    public class GetAllRoomQueryHandler : IRequestHandler<GetAllRoomQuery, ServiceResponse<List<RoomViewDto>>>
    {
        private readonly IRoomRepository _RoomRepository;
        IBuildingRepository _buildingRepository;

        private readonly IMapper _mapper;

        public GetAllRoomQueryHandler(IRoomRepository RoomRepository, IMapper mapper, IBuildingRepository buildingRepository)
        {
            _RoomRepository = RoomRepository;
            _mapper = mapper;
            _buildingRepository = buildingRepository;
        }

        public async Task<ServiceResponse<List<RoomViewDto>>> Handle(GetAllRoomQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RoomRepository.GetAllAsync(d => d.Building);

                var res = _mapper.Map<List<RoomViewDto>>(data);

                return new ServiceResponse<List<RoomViewDto>>(res);
            }
            catch (Exception e)
            {

                return new ServiceResponse<List<RoomViewDto>>(message: "işlem başarısız");
            }
        }


    }
}
