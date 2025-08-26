using NZWalks.Models.Domain;
using NZWalks.Models.DTO;

namespace NZWalks.Repository
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsyc(Walk walk);
        Task<List<Walk>> GetAllAsync();
        Task<Walk?> GetByIdAsync(Guid id);
        Task<Walk?> UpdateWalkAsync(Guid id,Walk walk);
        Task<Walk?> DeleteWalkAsync(Guid id);
    }
}
