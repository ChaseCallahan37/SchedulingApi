using System.Collections.Generic;
using System;

namespace Models
{

    public class ResourceModel : IComparable<ResourceModel>
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string EventSize { get; set; }
        public List<DateTime> Availability { get; set; }

        public ResourceModel()
        {

        }

        public ResourceModel(string id, string name, List<DateTime> availability, string type, string eventSize)
        {
            Id = id;
            Name = name;
            Availability = availability;
            Type = type;
            EventSize = eventSize;
        }

        public int CompareTo(ResourceModel other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}