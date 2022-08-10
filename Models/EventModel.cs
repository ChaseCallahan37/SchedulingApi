using System.Collections.Generic;
using System;

namespace Models
{
    public class EventModel : IComparable<EventModel>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string EventSize { get; set; }
        public List<DateTime> Availability { get; set; }

        public EventModel()
        {

        }

        public EventModel(string id, string name, List<DateTime> availability, string eventSize)
        {
            this.Id = id;
            this.Name = name;
            this.Availability = availability;
            this.EventSize = eventSize;
        }



        public int CompareTo(EventModel other)
        {
            return this.Name.CompareTo(other.Name);
        }

        public string ToString()
        {
            return $"ID: {this.Id} Name: {this.Name} Event Size: {this.EventSize}";
        }

    }
}