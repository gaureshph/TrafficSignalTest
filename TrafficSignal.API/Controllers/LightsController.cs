using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrafficSignal.API.Repositories;
using TrafficSignal.Web.DomainModels;

namespace TrafficSignal.API.Controllers
{
    [Route("api/lights")]
    [ApiController]
    public class LightsController : ControllerBase
    {
        private readonly ILightsRepository _lightsRepository;

        public LightsController(ILightsRepository lightsRepository)
        {
            _lightsRepository = lightsRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetLights()
        {
            var lights = await _lightsRepository.GetLightsAsync();

            if (lights == null || !lights.Any())
            {
                return NotFound();
            }

            var lightsDto = lights.Select(light => new LightDto
            {
                Id = light.Id,
                Name = light.Name,
                Duration = light.Duration,
                JunctionId = light.JunctionId,
                Order = light.Order,
                StatusId = light.StatusId                
            });

            return Ok(lightsDto);
        }

        [HttpGet("{lightId:int}", Name = "GetLight")]
        public async Task<ActionResult> GetLight(int lightId)
        {
            var light = await _lightsRepository.GetLightAsync(lightId);

            if (light == null)
            {
                return NotFound();
            }

            var lightDto = new LightDto
            {
                Id = light.Id,
                Name = light.Name,
                Duration = light.Duration,
                JunctionId = light.JunctionId,
                Order = light.Order,
                StatusId = light.StatusId,
                StatusChangeDateTime = light.StatusChangeDateTime
            };

            return Ok(lightDto);
        }

        [HttpPost]
        public async Task<ActionResult> AddLight([FromBody] LightDto lightDto)
        {
            var light = new TrafficLight
            {
                Id = lightDto.Id,
                Name = lightDto.Name,
                Duration = lightDto.Duration,
                JunctionId = lightDto.JunctionId,
                Order = lightDto.Order,
                StatusId = lightDto.StatusId
            };

            var lightId = await _lightsRepository.AddLightAsync(light);

            return CreatedAtRoute("GetLight", new { lightId }, null);
        }

        [HttpPut("{lightId:int}")]
        public async Task<ActionResult> UpdateLight(int lightId, [FromBody] LightDto lightDto)
        {
            var light = await _lightsRepository.GetLightAsync(lightId);

            if (light == null)
            {
                return NotFound();
            }

            await _lightsRepository.UpdateLightAsync(lightId, light);

            return NoContent();
        }

        [HttpDelete("{lightId:int}")]
        public async Task<ActionResult> DeleteLight(int lightId)
        {
            var light = await _lightsRepository.GetLightAsync(lightId);

            if (light == null)
            {
                return NotFound();
            }

            await _lightsRepository.DeleteLightAsync(lightId);

            return NoContent();
        }
    }
}
