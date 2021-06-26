using System.Collections.Generic;

namespace TrafficSignal.Web.DomainModels
{
    public class TrafficJunction : ModificationHistory
    {
        public TrafficJunction()
        {
            Lights = new HashSet<TrafficLight>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public ICollection<TrafficLight> Lights { get; set; }
    }
}