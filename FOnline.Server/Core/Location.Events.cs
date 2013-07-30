using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FOnline
{
    public class LocationEventArgs : EventArgs
    {
        public LocationEventArgs (Location location)
        {
            this.Location = location;
        }

        public Location Location { get; private set; }
    }

    public class LocationChainEventArgs : DefaultEventArgs
    {
        public LocationChainEventArgs (Location location)
        {
            this.Location = location;
        }

        public Location Location { get; private set; }
    }

    public class LocationFinishEventArgs : LocationEventArgs
    {
        public LocationFinishEventArgs (Location location, bool to_delete)
            : base(location)
        {
            this.ToDelete = to_delete;
        }

        public bool ToDelete { get; private set; }
    }

    public class LocationEnterEventArgs : LocationChainEventArgs
    {
        public LocationEnterEventArgs (Location location, IList<Critter> group, ushort entrance) : base(location)
        {
            Group = group;
            Entrance = entrance;
        }

        public IList<Critter> Group { get; private set; }

        public ushort Entrance { get; private set; }
    }

    public partial class Location
    {
        /// <summary>
        /// Raised when map is about to be garbaged.
        /// </summary>
        public event EventHandler<LocationFinishEventArgs> Finish;
        // called by engine
        void RaiseFinish (bool to_delete)
        {
            if (Finish != null)
                Finish (this, new LocationFinishEventArgs (this, to_delete));
        }

        public event EventHandler<LocationEnterEventArgs> Enter;
        // called by engine
        bool RaiseEnter (IntPtr group, ushort entrance)
        {
            if (Enter != null) {
                var eventArgs = new LocationEnterEventArgs (this, new CritterArray (group), entrance);
                Enter (this, eventArgs);

                if (eventArgs.Prevent)
                    return false;
            }
            return true;
        }
    }
}
