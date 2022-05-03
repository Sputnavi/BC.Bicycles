using BC.Bicycles.Boundary.Features;
using BC.Bicycles.Models;
using BC.Bicycles.Repositories.Extensions;
using BC.Bicycles.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BC.Bicycles.Repositories
{
    public class BicycleRepository : RepositoryBase<Bicycle>, IBicycleRepository
    {
        public BicycleRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public Task CreateBicycleAsync(Bicycle bicycle) => CreateAsync(bicycle);

        public Task DeleteBicycleAsync(Bicycle bicycle) => DeleteAsync(bicycle);

        public Task UpdateBicycleAsync(Bicycle bicycle) => UpdateAsync(bicycle);

        public async Task<Bicycle> GetBicycleAsync(Guid id) =>
            await FindByCondition(p => p.Id.Equals(id)).SingleOrDefaultAsync();

        public async Task<PagedList<Bicycle>> GetBicyclesAsync(BicycleParameters bicycleParameters)
        {
            var bicycles = await FindAll()
                .Search(bicycleParameters.SearchTerm)
                .Sort(bicycleParameters.OrderBy)
                .ToListAsync();

            return PagedList<Bicycle>.ToPagedList(bicycles, bicycleParameters.PageNumber, bicycleParameters.PageSize);
        }
    }
}
