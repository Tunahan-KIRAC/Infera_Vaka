using AutoMapper;
using CorePackages.Application.Dto;
using CorePackages.Application.Interfaces.Repository;
using CorePackages.Application.Wrappers;
using MediatR;

namespace CorePackages.Application.Features.Queries.GetAllConfigurations;

public class GetAllConfigurationQuery : IRequest<ServiceResponse<List<ConfigurationDto>>>
{
    public class GetAllConfigurationQueryHandler : IRequestHandler<GetAllConfigurationQuery, ServiceResponse<List<ConfigurationDto>>>
    {
        private readonly IConfigurationRepository _configurationRepository;
        private readonly IMapper _mapper;

        public GetAllConfigurationQueryHandler(IConfigurationRepository configurationRepository, IMapper mapper)
        {
            _configurationRepository = configurationRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<ConfigurationDto>>> Handle(GetAllConfigurationQuery request, CancellationToken cancellationToken)
        {
            var data = await _configurationRepository.GetAllAsync();

            var res = _mapper.Map<List<ConfigurationDto>>(data);

            return new ServiceResponse<List<ConfigurationDto>>(res);
        }


    }
}
