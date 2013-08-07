using System;

namespace FOnline.Client
{
    public class Main
    {
        public static event EventHandler<SuccessEventArgs> Start;
        // called by engine
        static bool RaiseStart()
        {
            var e = new SuccessEventArgs ();
            if(Start != null)
            {
                Start (null, e);
            }
            return e.Success;
        }

        public static event EventHandler Loop;
        // called by engine
        static uint RaiseLoop()
        {
            if (Loop != null)
                Loop (null, EventArgs.Empty);
            // TODO: this value should not come from event, bur rather be configurable
            return 100;
        }
    }
}
