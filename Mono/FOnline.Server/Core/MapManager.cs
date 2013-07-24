using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

namespace FOnline
{
    public interface IMapManager
    {
        uint CreateLocation(ushort pid, ushort wx, ushort wy, IList<Critter> critters);
        void DeleteLocation(uint loc_id);
        Location GetLocation(uint loc_id);
        Location GetLocationByPid(ushort pid, uint skip_count);
        uint GetLocations(ushort wx, ushort wy, uint radius, IList<Location> locations);
        uint GetVisibleLocations(ushort wx, ushort wy, uint radius, Critter visible_for, IList<Location> locations);
        uint GetZoneLocationIds(ushort zx, ushort zy, uint zone_radius, IList<uint> location_ids);

        Map FromNativeMap(IntPtr ptr);
        Map GetMap(uint map_id);
        Map GetMapByPid(ushort pid, uint skip_count);

        uint GetAllMaps(ushort pid, IList<Map> maps);
        uint GetAllLocations(ushort pid, IList<Location> locations);
    }
    /// <summary>
    /// Exposes global map/location managing facilities.
    /// </summary>
    public class MapManager : IMapManager
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static Map Map_FromNative(IntPtr ptr);
        public Map FromNativeMap(IntPtr ptr)
        {
            return Map_FromNative(ptr);
        }
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint Global_CreateLocation(ushort pid, ushort wx, ushort wy, IList<Critter> critters);
        public uint CreateLocation(ushort pid, ushort wx, ushort wy, IList<Critter> critters)
        {
            return Global_CreateLocation(pid, wx, wy, critters);
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void Global_DeleteLocation(uint loc_id);
        public void DeleteLocation(uint loc_id)
        {
            Global_DeleteLocation(loc_id);
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static IntPtr Global_GetLocation(uint loc_id);
        public Location GetLocation(uint loc_id)
        {
            return new Location(Global_GetLocation(loc_id));
        }
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static IntPtr Global_GetLocationByPid(ushort pid, uint skip_count);
        public Location GetLocationByPid(ushort pid, uint skip_count)
        {
            return new Location(Global_GetLocationByPid(pid, skip_count));
        }
        
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint Global_GetLocations(ushort wx, ushort wy, uint radius, IList<Location> locations);
        public uint GetLocations(ushort wx, ushort wy, uint radius, IList<Location> locations)
        {
            return Global_GetLocations(wx, wy, radius, locations);
        }
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint Global_GetVisibleLocations(ushort wx, ushort wy, uint radius, IntPtr visible_for, IList<Location> locations);
        public uint GetVisibleLocations(ushort wx, ushort wy, uint radius, Critter visible_for, IList<Location> locations)
        {
            return Global_GetVisibleLocations(wx, wy, radius, visible_for.ThisPtr, locations);
        }
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint Global_GetZoneLocationIds(ushort zx, ushort zy, uint zone_radius, IList<uint> location_ids);
        public uint GetZoneLocationIds(ushort zx, ushort zy, uint zone_radius, IList<uint> location_ids)
        {
            return Global_GetZoneLocationIds(zx, zy, zone_radius, location_ids);
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static IntPtr Global_GetMap(uint map_id);
        public Map GetMap(uint map_id)
        {
            return (Map)Global_GetMap(map_id);
        }
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static IntPtr Global_GetMapByPid(ushort pid, uint skip_count);
        public Map GetMapByPid(ushort pid, uint skip_count)
        {
            return (Map)Global_GetMapByPid(pid, skip_count);
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint Global_GetAllMaps(ushort pid, IList<Map> array);
        public uint GetAllMaps(ushort pid, IList<Map> maps)
        {
            return Global_GetAllMaps(pid, maps);
        }
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint Global_GetAllLocations(ushort pid, IList<Location> array);
        public uint GetAllLocations(ushort pid, IList<Location> locations)
        {
            return Global_GetAllLocations(pid, locations);
        }
    }
}
