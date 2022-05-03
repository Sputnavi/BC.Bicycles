using BC.Bicycles.Boundary.Features;
using BC.Bicycles.Models;
using System.Linq.Expressions;

namespace BC.Bicycles.Repositories.Interfaces
{
    public interface IBicycleRepository
    {
        Task<PagedList<Bicycle>> GetBicyclesAsync(BicycleParameters bicycleParameters);
        Task<Bicycle> GetBicycleAsync(Guid id);
        Task CreateBicycleAsync(Bicycle bicycle);
        Task DeleteBicycleAsync(Bicycle bicycle);
        Task UpdateBicycleAsync(Bicycle bicycle);
        bool Exist(Expression<Func<Bicycle, bool>> expression);
    }
}
