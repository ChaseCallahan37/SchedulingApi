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
            AllEvents = DatabaseAccess.GetEvents();
            AllEvents.Sort();
            return AllEvents;
        }

        public static EventModel AddEvent(EventModel newEvent)
        {
            DatabaseAccess.CreateEvent(newEvent);
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
            DatabaseAccess.DeleteEvent(id);
            DatabaseAccess.CreateEvent(newEvent);
            return newEvent;
        }


        public static EventModel DeleteEvent(string id)
        {
            EventModel toDelete = AllEvents.Find(c => c.Id.Equals(id));
            bool success = DatabaseAccess.DeleteEvent(id);
            if (success)
            {
                return toDelete;
            }
            return new EventModel();
        }
    }
}