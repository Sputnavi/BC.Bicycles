using BC.Bicycles.Repositories.Interfaces;
using BC.Messaging;
using MassTransit;
using System.Text.Json;

namespace BC.Bicycles.Services
{
    public class UserUpdatedConsumer : IConsumer<UserUpdated>
    {
        private readonly ILogger<UserUpdatedConsumer> _logger;
        // ToDo: add logic later.
        private readonly IBicycleRepository _bicycleRepository;

        public UserUpdatedConsumer(ILogger<UserUpdatedConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<UserUpdated> context)
        {
            var json = JsonSerializer.Serialize(context.Message);
            _logger.LogInformation(json);
            return Task.CompletedTask;
        }
    }
}
