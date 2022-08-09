using Models;
using System.Collections.Generic;
using Database;

namespace DataAccess
{
    public class EventData
    {

        public static List<EventModel> AllEvents { get; set; }
        public static List<EventModel> GetAllEvents()
        {
            AllEvents = EventDb.GetEvents();
            AllEvents.Sort();
            return AllEvents;
        }

        public static EventModel AddEvent(EventModel newEvent)
        {
            EventDb.CreateEvent(newEvent);
            return newEvent;
        }

        public static bool CheckIsPresent(EventModel newEvent)
        {
            foreach (EventModel eventSearch in AllEvents)
            {
                if (newEvent == eventSearch)
                {
                    return true;
                }
            }
            return false;
        }

        public static EventModel UpdateEvent(string id, EventModel newEvent)
        {
            int index = AllEvents.FindIndex(c => c.Id.Equals(id));
            AllEvents.RemoveAt(index);
            EventData.DeleteEvent(id);
            EventDb.CreateEvent(newEvent);
            return newEvent;
        }


        public static EventModel DeleteEvent(string id)
        {
            EventModel toDelete = AllEvents.Find(c => c.Id.Equals(id));
            bool success = EventDb.DeleteEvent(id);
            if (success)
            {
                return toDelete;
            }
            return new EventModel();
        }
    }
}