using BC.Bicycles.Boundary.Features;
using BC.Bicycles.Models;
using BC.Messaging;

namespace BC.Bicycles.Repositories.Interfaces
{
    public interface IBicycleRepository
    {
        Task<PagedList<Bicycle>> GetBicyclesAsync(BicycleParameters bicycleParameters);
        Task<Bicycle> GetBicycleAsync(Guid id);
        Task CreateBicycleAsync(Bicycle bicycle);
        Task DeleteBicycleAsync(Bicycle bicycle);
        Task UpdateBicycleAsync(Bicycle bicycle);
        Task UpdateBicyclesUserInfoAsync(UserUpdated userUpdated);
        Task DeleteBicyclesUserInfoAsync(UserDeleted userUpdated);
    }
}
