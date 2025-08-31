using System.ComponentModel.DataAnnotations;

namespace NZWalks.Models.DTO
{
    public class AddRegionRequestDto
    {
        [Required]
        [MaxLength(3,ErrorMessage = "name should be of maximun length 100")]
        public string Name { get; set; }
        [Required]
        [MaxLength(3,ErrorMessage = "code should be of lenght 3")]
        [MinLength(3,ErrorMessage = "code should be of lenght 3")]
        public string Code { get; set; }

        public string? RegionImageURL { get; set; }
    }
}
