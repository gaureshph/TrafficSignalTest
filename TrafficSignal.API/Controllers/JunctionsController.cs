using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrafficSignal.API.Repositories;
using TrafficSignal.Web.DomainModels;

namespace TrafficSignal.API.Controllers
{
    [Route("api/junctions")]
    [ApiController]
    public class JunctionsController : ControllerBase
    {
        private readonly IJunctionsRepository _junctionsRepository;

        public JunctionsController(IJunctionsRepository junctionsRepository)
        {
            _junctionsRepository = junctionsRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetJunctions()
        {
            var junctions = await _junctionsRepository.GetJunctionsAsync();

            if (junctions == null || !junctions.Any())
            {
                return NotFound();
            }

            var junctionsDto = junctions.Select(junction => new JunctionDto
            {
                Id = junction.Id,
                Name = junction.Name,
                IsActive = junction.IsActive
            });

            return Ok(junctionsDto);
        }

        [HttpGet("{junctionId:int}", Name = "GetJunction")]
        public async Task<ActionResult> GetJunction(int junctionId)
        {
            var junction = await _junctionsRepository.GetJunctionAsync(junctionId);

            if (junction == null)
            {
                return NotFound();
            }

            var junctionDto = new JunctionDto
            {
                Id = junction.Id,
                Name = junction.Name,
                IsActive = junction.IsActive
            };

            return Ok(junctionDto);
        }

        [HttpGet("{junctionId:int}/lights")]
        public async Task<ActionResult> GetJunctionLights(int junctionId)
        {
            var lights = await _junctionsRepository.GetLightsAsync(junctionId);

            var lightsDto = lights.Select(light => new LightDto
            {
                Id = light.Id,
                Name = light.Name,
                Duration = light.Duration,
                JunctionId = light.JunctionId,
                Order = light.Order,
                StatusId = light.StatusId,
                StatusChangeDateTime = light.StatusChangeDateTime
            });

            return Ok(lightsDto);
        }

        [HttpPost]
        public async Task<ActionResult> AddJunction([FromBody] JunctionDto junctionDto)
        {
            var junction = new TrafficJunction
            {
                Id = junctionDto.Id,
                Name = junctionDto.Name,
                IsActive = junctionDto.IsActive
            };

            var junctionId = await _junctionsRepository.AddJunctionAsync(junction);

            return CreatedAtRoute("GetJunction", new { junctionId }, null);
        }

        [HttpPut("{junctionId:int}")]
        public async Task<ActionResult> UpdateJunction(int junctionId, [FromBody] JunctionDto junctionDto)
        {
            var junction = await _junctionsRepository.GetJunctionAsync(junctionId);

            if (junction == null)
            {
                return NotFound();
            }

            await _junctionsRepository.UpdateJunctionAsync(junctionId, junction);

            return NoContent();
        }

        [HttpDelete("{junctionId:int}")]
        public async Task<ActionResult> DeleteJunction(int junctionId)
        {
            var junction = await _junctionsRepository.GetJunctionAsync(junctionId);

            if (junction == null)
            {
                return NotFound();
            }

            await _junctionsRepository.DeleteJunctionAsync(junctionId);

            return NoContent();
        }
    }
}
