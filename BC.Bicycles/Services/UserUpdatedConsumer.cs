using BC.Bicycles.Repositories.Interfaces;
using BC.Messaging;
using MassTransit;

namespace BC.Bicycles.Services
{
    public class UserUpdatedConsumer : IConsumer<UserUpdated>
    {
        private readonly ILogger<UserUpdatedConsumer> _logger;
        private readonly IBicycleRepository _bicycleRepository;

        public UserUpdatedConsumer(ILogger<UserUpdatedConsumer> logger, IBicycleRepository bicycleRepository)
        {
            _logger = logger;
            _bicycleRepository = bicycleRepository;
        } 

        public async Task Consume(ConsumeContext<UserUpdated> context)
        {
            var message = context.Message;
            _logger.LogInformation($"Got UserUpdated event: {message}");

            await _bicycleRepository.UpdateBicyclesUserInfoAsync(message);
        }
    }
}
