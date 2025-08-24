using Microsoft.EntityFrameworkCore;
using NZWalks.Data;
using NZWalks.Models.Domain;

namespace NZWalks.Repository
{
    public class SqlRegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext dbContext;

        public SqlRegionRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Region> CreateRegionAsync(Region region)
        {
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<List<Region>> GetAllRegionAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetRegionByIdAsync(Guid id)
        {
            return await dbContext.Regions.FirstOrDefaultAsync<Region>(x => x.Id == id);
        }

        public async Task<Region?> DeleteRegionAsync(Guid id)
        {
            var regionModel = await dbContext.Regions.FindAsync(id);
            if (regionModel == null)
            {
                return null;
            }

            dbContext.Regions.Remove(regionModel);
            await dbContext.SaveChangesAsync();
            return regionModel;
        }

        public async Task<Region?> UpdateRegionAsync(Guid id,Region regionModel)
        {
            var regionDomain = await dbContext.Regions.FindAsync(id);
            if (regionDomain == null)
            {
                return null;
            }

            regionDomain.Name = regionModel.Name;
            regionDomain.Code = regionModel.Code;
            regionDomain.RegionImageURL = regionModel.RegionImageURL;

            await dbContext.SaveChangesAsync();
            return regionDomain;
        }
    }
}
