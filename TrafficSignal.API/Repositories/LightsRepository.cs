using System.Threading.Tasks;
using System.Collections.Generic;
using TrafficSignal.API.DbContexts;
using Microsoft.EntityFrameworkCore;
using TrafficSignal.Web.DomainModels;

namespace TrafficSignal.API.Repositories
{
    public class LightsRepository: ILightsRepository
    {
        private readonly TrafficSignalDBContext _trafficSignalDBContext;

        public LightsRepository(TrafficSignalDBContext trafficSignalDBContext)
        {
            _trafficSignalDBContext = trafficSignalDBContext;
        }

        public async Task<int> AddLightAsync(TrafficLight light)
        {
            _trafficSignalDBContext.TrafficLights.Add(light);
            await _trafficSignalDBContext.SaveChangesAsync();
            return light.Id;
        }

        public async Task DeleteLightAsync(int lightId)
        {
            var light = await _trafficSignalDBContext.TrafficLights.FindAsync(lightId);
            _trafficSignalDBContext.TrafficLights.Remove(light);
            await _trafficSignalDBContext.SaveChangesAsync();
        }

        public async Task<TrafficLight> GetLightAsync(int lightId)
        {
            return await _trafficSignalDBContext.TrafficLights.FindAsync(lightId);
        }

        public async Task<List<TrafficLight>> GetLightsAsync()
        {
            return await _trafficSignalDBContext.TrafficLights.ToListAsync();
        }

        public async Task UpdateLightAsync(int lightId, TrafficLight light)
        {
            _trafficSignalDBContext.TrafficLights.Update(light);
            await _trafficSignalDBContext.SaveChangesAsync();
        }
    }
}