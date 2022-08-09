using Models;
using System.Collections.Generic;
using Database;

namespace DataAccess
{
    public class ResourceData
    {

        public static List<ResourceModel> AllResources { get; set; }
        public static List<ResourceModel> GetAllResources()
        {
            AllResources = ResourceDb.GetResources();
            AllResources.Sort();
            return AllResources;
        }

        public static ResourceModel AddResource(ResourceModel newResource)
        {
            ResourceDb.CreateResource(newResource);
            return newResource;
        }

        public static bool CheckIsPresent(ResourceModel newResource)
        {
            foreach (ResourceModel ResourceSearch in AllResources)
            {
                if (newResource == ResourceSearch)
                {
                    return true;
                }
            }
            return false;
        }

        public static ResourceModel UpdateResource(string id, ResourceModel newResource)
        {
            int index = AllResources.FindIndex(c => c.Id.Equals(id));
            AllResources.RemoveAt(index);
            ResourceDb.DeleteResource(id);
            ResourceDb.CreateResource(newResource);
            return newResource;
        }


        public static ResourceModel DeleteResource(string id)
        {
            ResourceModel toDelete = AllResources.Find(c => c.Id.Equals(id));
            bool success = ResourceDb.DeleteResource(id);
            if (success)
            {
                return toDelete;
            }
            return new ResourceModel();
        }
    }
}