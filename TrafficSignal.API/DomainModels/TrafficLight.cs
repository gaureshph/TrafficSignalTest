using System;

namespace TrafficSignal.Web.DomainModels
{
    public class TrafficLight : ModificationHistory
    {
        public TrafficLight()
        {
            Junction = new TrafficJunction();
        }

        public int Id { get; set; }
        public int Name { get; set; }
        public int JunctionId { get; set; }
        public TrafficJunction Junction { get; set; }
        public int Order { get; set; }
        public int Duration { get; set; }
        public int StatusId { get; set; }
        public DateTime? StatusChangeDateTime { get; set; }
    }
}