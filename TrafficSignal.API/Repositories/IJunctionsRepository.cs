using System.Threading.Tasks;
using System.Collections.Generic;
using TrafficSignal.Web.DomainModels;

namespace TrafficSignal.API.Repositories
{
    public interface IJunctionsRepository
    {
        Task<List<TrafficJunction>> GetJunctionsAsync();
        Task<List<TrafficLight>> GetLightsAsync(int junctionId);
        Task<TrafficJunction> GetJunctionAsync(int junctionId);
        Task<int> AddJunctionAsync(TrafficJunction junction);
        Task UpdateJunctionAsync(int junctionId, TrafficJunction junction);
        Task DeleteJunctionAsync(int junctionId);
    }
}
