using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.CustomActionFilters;
using NZWalks.Data;
using NZWalks.Models.Domain;
using NZWalks.Models.DTO;
using NZWalks.Repository;

namespace NZWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<RegionDto>>> GetAllRegions()
        {
            var regions = await regionRepository.GetAllRegionAsync();

            List<RegionDto> regionsDto = new();

            foreach (var region in regions)
            {
                regionsDto.Add(mapper.Map<RegionDto>(region));
            }

            return Ok(regionsDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<ActionResult<RegionDto>> GetRegionById([FromRoute] Guid id)
        {
            var region = await regionRepository.GetRegionByIdAsync(id);
            if (region == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<RegionDto>(region));
        }

        [HttpPost]
        [ValidateModel]
        public async Task<ActionResult<RegionDto>> CreateRegion([FromBody] AddRegionRequestDto regionRequestDto)
        {
            var regionDomain = mapper.Map<Region>(regionRequestDto);

            regionDomain = await regionRepository.CreateRegionAsync(regionDomain);

            var regionDto = mapper.Map<RegionDto>(regionDomain);

            return CreatedAtAction(nameof(GetRegionById), new { id = regionDto.Id }, regionDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<ActionResult<RegionDto>> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto regionRequestDto)
        {
            var regionDomain = mapper.Map<Region>(regionRequestDto);

            regionDomain = await regionRepository.UpdateRegionAsync(id, regionDomain);
            if (regionDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<RegionDto>(regionDomain));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<ActionResult> DeleteRegion([FromRoute] Guid id)
        {
            var regionModel = await regionRepository.DeleteRegionAsync(id);
            if (regionModel == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
