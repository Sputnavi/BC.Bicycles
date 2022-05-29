using BC.Bicycles.Boundary.Features;
using BC.Bicycles.Models;
using BC.Bicycles.Repositories.Extensions;
using BC.Bicycles.Repositories.Interfaces;
using BC.Messaging;
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

        public async Task<List<Bicycle>> GetBicyclesForUserAsync(Guid userId) =>
            await FindByCondition(b => b.UserId.Equals(userId)).ToListAsync();

        public async Task<PagedList<Bicycle>> GetBicyclesAsync(BicycleParameters bicycleParameters)
        {
            var bicycles = await FindAll()
                .Search(bicycleParameters.SearchTerm)
                .Sort(bicycleParameters.OrderBy)
                .ToListAsync();

            return PagedList<Bicycle>.ToPagedList(bicycles, bicycleParameters.PageNumber, bicycleParameters.PageSize);
        }

        public async Task UpdateBicyclesUserInfoAsync(UserUpdated userUpdated)
        {
            var bicyclesToUpdate = FindByCondition(x => x.UserId == userUpdated.Id);

            foreach (var bicycle in bicyclesToUpdate)
            {
                bicycle.Email = userUpdated.Email;
            }

            await _repositoryContext.SaveChangesAsync();
        }

        public async Task DeleteBicyclesUserInfoAsync(UserDeleted userUpdated)
        {
            var bicyclesToUpdate = FindByCondition(x => x.UserId == userUpdated.Id);

            foreach (var bicycle in bicyclesToUpdate)
            {
                bicycle.UserId = null;
            }

            await _repositoryContext.SaveChangesAsync();
        }
    }
}
