using AutoMapper;
using CorePackages.Application.Interfaces.Repository;
using CorePackages.Application.Wrappers;
using CorePackages.Domain.Entities;
using MediatR;

namespace CorePackages.Application.Features.Commands;

public class CreateConfiguration : IRequest<ServiceResponse<Guid>>
{
    public string Name { get; set; }
    public string Type { get; set; }
    public string Value { get; set; }
    public bool IsActive { get; set; }
    public string ApplicationName { get; set; }

    public class CreateConfigurationHandler : IRequestHandler<CreateConfiguration, ServiceResponse<Guid>>
    {
        IConfigurationRepository _configurationRepository;
        private readonly IMapper mapper;

        public CreateConfigurationHandler(IConfigurationRepository configurationRepository, IMapper mapper)
        {
            _configurationRepository = configurationRepository;
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<Guid>> Handle(CreateConfiguration request, CancellationToken cancellationToken)
        {
            var data = mapper.Map<Configuration>(request);

            await _configurationRepository.AddAsync(data);

            return new ServiceResponse<Guid>(data.Id);
        }
    }
}
