using System.Threading.Tasks;
using System.Collections.Generic;
using TrafficSignal.Web.DomainModels;

namespace TrafficSignal.API.Repositories
{
    public interface ILightsRepository
    {
        Task<List<TrafficLight>> GetLightsAsync();
        Task<TrafficLight> GetLightAsync(int lightId);
        Task<int> AddLightAsync(TrafficLight light);
        Task UpdateLightAsync(int lightId, TrafficLight light);
        Task DeleteLightAsync(int lightId);
    }
}
