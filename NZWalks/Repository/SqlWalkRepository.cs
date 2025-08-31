using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
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

        public async Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 1000)
        {
            var walks = dbContext.Walks.Include("Difficulty").Include("Region").AsQueryable();
            //filtering
            if (!string.IsNullOrWhiteSpace(filterOn) && !string.IsNullOrWhiteSpace(filterQuery))
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Name.Contains(filterQuery));
                }
            }

            //sorting
            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
                }
                else if (sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x => x.LengthInKm) : walks.OrderByDescending(x => x.LengthInKm);
                }
            }

            //pagination
            var skipNum = (pageNumber - 1) * pageSize;

            return await walks.Skip(skipNum).Take(pageSize).ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await dbContext.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(walk => walk.Id == id);
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
