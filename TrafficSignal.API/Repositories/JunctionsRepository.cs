using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using TrafficSignal.API.DbContexts;
using Microsoft.EntityFrameworkCore;
using TrafficSignal.Web.DomainModels;

namespace TrafficSignal.API.Repositories
{
    public class JunctionsRepository : IJunctionsRepository
    {
        private readonly TrafficSignalDBContext _trafficSignalDBContext;

        public JunctionsRepository(TrafficSignalDBContext trafficSignalDBContext)
        {
            _trafficSignalDBContext = trafficSignalDBContext;
        }

        public async Task<int> AddJunctionAsync(TrafficJunction junction)
        {
            _trafficSignalDBContext.TrafficJunctions.Add(junction);
            await _trafficSignalDBContext.SaveChangesAsync();
            return junction.Id;
        }

        public async Task DeleteJunctionAsync(int junctionId)
        {
            var junction = await _trafficSignalDBContext.TrafficJunctions.FindAsync(junctionId);
            _trafficSignalDBContext.TrafficJunctions.Remove(junction);
            await _trafficSignalDBContext.SaveChangesAsync();
        }

        public async Task<TrafficJunction> GetJunctionAsync(int junctionId)
        {
            return await _trafficSignalDBContext.TrafficJunctions.FindAsync(junctionId);
        }

        public async Task<List<TrafficJunction>> GetJunctionsAsync()
        {
            return await _trafficSignalDBContext.TrafficJunctions.ToListAsync();
        }

        public async Task<List<TrafficLight>> GetLightsAsync(int junctionId)
        {
            return await _trafficSignalDBContext.TrafficLights.Where(light => light.JunctionId == junctionId).ToListAsync();
        }

        public async Task UpdateJunctionAsync(int junctionId, TrafficJunction junction)
        {
            _trafficSignalDBContext.TrafficJunctions.Update(junction);
            await _trafficSignalDBContext.SaveChangesAsync();
        }
    }
}