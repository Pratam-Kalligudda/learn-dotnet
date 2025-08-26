using NZWalks.Models.Domain;

namespace NZWalks.Models.DTO
{
    public class AddWalkRequestDto
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required double LengthInKm { get; set; }
        public string? WalkImageURL { get; set; }
        public required Guid DifficultyId { get; set; }
        public required Guid RegionId { get; set; }
    }
}
