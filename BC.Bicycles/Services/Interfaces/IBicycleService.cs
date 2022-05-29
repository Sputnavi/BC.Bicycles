using BC.Bicycles.Boundary.Features;
using BC.Bicycles.Boundary.Request;
using BC.Bicycles.Boundary.Response;

namespace BC.Bicycles.Services.Interfaces
{
    public interface IBicycleService
    {
        Task<List<BicycleForReadModel>> GetBicycleListAsync(BicycleParameters bicycleParameters, HttpResponse response);
        Task<List<BicycleForReadModel>> GetBicyclesForUserAsync(Guid userId);
        Task<BicycleForReadModel> GetBicycleAsync(Guid id);
        Task<Guid> CreateBicycleAsync(BicycleForCreateOrUpdateModel model);
        Task UpdateBicycleAsync(Guid id, BicycleForCreateOrUpdateModel model);
        Task DeleteBicycleAsync(Guid id);
        Task<BicycleForCreateOrUpdateModel> GetBicycleForUpdateModelAsync(Guid id);
    }
}
