using System;

namespace TrafficSignal.Web.DomainModels
{
    public class LightDto
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int JunctionId { get; set; }
        public int Order { get; set; }
        public int Duration { get; set; }
        public int StatusId { get; set; }
        public DateTime? StatusChangeDateTime { get; set; }
    }
}
