using System;

namespace FOnline.Server
{
    public static class EngineTypeExtensions
    {
        // following extensions allow cleaner tests
        // in case when you want to check for either null instance
        // or instance that points to cleared engine structure
        public static bool IsNullOrNotValid(this Critter cr)
        {
            return cr == null || cr.IsNotValid;
        }
        public static bool IsNullOrNotValid(this Item item)
        {
            return item == null || item.IsNotValid;
        }
        public static bool IsNullOrNotValid(this Map map)
        {
            return map == null || map.IsNotValid; 
        }
        public static bool IsNullOrNotValid(this Location loc)
        {
            return loc == null || loc.IsNotValid;
        }
    }
}

