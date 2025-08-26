using System.Runtime.CompilerServices;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Models.Domain;
using NZWalks.Models.DTO;
using NZWalks.Repository;

namespace NZWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper,IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }

        [HttpPost]
        public async Task<ActionResult<WalkDto>> CreateWalk([FromBody]AddWalkRequestDto addWalkRequest)
        {
            var walk = mapper.Map<Walk>(addWalkRequest);

            await walkRepository.CreateAsyc(walk);

            return Ok(mapper.Map<WalkDto>(walk));
        }

        [HttpGet]
        public async Task<ActionResult<List<WalkDto>>> GetAllWalk()
        {
            var walks = await walkRepository.GetAllAsync();

            return mapper.Map<List<WalkDto>>(walks);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<ActionResult<WalkDto>> GetWalkById([FromRoute]Guid id)
        {
            var walkDomain = await walkRepository.GetByIdAsync(id);
            if (walkDomain == null)
            {
                return NotFound();
            }
            return mapper.Map<WalkDto>(walkDomain);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<ActionResult<WalkDto>> UpdateWalk([FromRoute]Guid id,UpdateWalkRequestDto updateWalkRequestDto)
        {
            var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDto);

            await walkRepository.UpdateWalkAsync(id, walkDomainModel);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<ActionResult<WalkDto>> DeleteWalk([FromRoute]Guid id)
        {
            var deletedWalk = await walkRepository.DeleteWalkAsync(id);
            if (deletedWalk == null)
            {
                return NotFound();
            }
            return mapper.Map<WalkDto>(deletedWalk);
        }
    }
}
