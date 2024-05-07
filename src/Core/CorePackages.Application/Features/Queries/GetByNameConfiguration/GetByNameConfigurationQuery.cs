using AutoMapper;
using CorePackages.Application.Dto;
using CorePackages.Application.Interfaces.Repository;
using CorePackages.Application.Wrappers;
using MediatR;

namespace CorePackages.Application.Features.Queries.GetByNameConfiguration
{
    public class GetByNameConfigurationQuery : IRequest<ServiceResponse<ConfigurationDto>>
    {
        public string Name { get; set; }

        public class GetByNameConfigurationQueryHandler : IRequestHandler<GetByNameConfigurationQuery, ServiceResponse<ConfigurationDto>>
        {
            private readonly IConfigurationRepository _configurationRepository;
            private readonly IMapper _mapper;

            public GetByNameConfigurationQueryHandler(IMapper mapper, IConfigurationRepository configurationRepository)
            {
                _mapper = mapper;
                _configurationRepository = configurationRepository;
            }

            public async Task<ServiceResponse<ConfigurationDto>> Handle(GetByNameConfigurationQuery request, CancellationToken cancellationToken)
            {
                var data = await _configurationRepository.GetByNameAsync(request.Name);

                var res = _mapper.Map<ConfigurationDto>(data);

                return new ServiceResponse<ConfigurationDto>(res);
            }
        }
    }
}
