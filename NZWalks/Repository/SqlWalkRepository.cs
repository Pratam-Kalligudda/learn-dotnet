using Microsoft.EntityFrameworkCore;
using NZWalks.Data;
using NZWalks.Models.Domain;
using NZWalks.Models.DTO;

namespace NZWalks.Repository
{
    public class SqlWalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext dbContext;

        public SqlWalkRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Walk> CreateAsyc(Walk walk)
        {
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk?> DeleteWalkAsync(Guid id)
        {
            var exisitingWalk = await dbContext.Walks.FindAsync(id);
            if (exisitingWalk == null)
            {
                return null;
            }
            dbContext.Walks.Remove(exisitingWalk);
            await dbContext.SaveChangesAsync();
            return exisitingWalk;
        }

        public async Task<List<Walk>> GetAllAsync()
        {
            return await dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await dbContext.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(walk=>walk.Id==id);
        }

        public async Task<Walk?> UpdateWalkAsync(Guid id, Walk walk)
        {
            var exisitinWalk = await dbContext.Walks.FindAsync(id);
            if (exisitinWalk == null)
            {
                return null;
            }
            exisitinWalk.Name = walk.Name;
            exisitinWalk.Region = walk.Region;
            exisitinWalk.WalkImageURL = walk.WalkImageURL;
            exisitinWalk.DifficultyId = walk.DifficultyId;
            exisitinWalk.RegionId = walk.RegionId;

            await dbContext.SaveChangesAsync();
            return exisitinWalk;
        }
    }
}
