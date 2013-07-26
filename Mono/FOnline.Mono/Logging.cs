using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

namespace FOnline
{
    public interface ILogging
    {
        void Log(string message);
        void Log(string message, params object[] args);
        string GetLastError();
    }
    public class Logging : ILogging
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void Global_Log(string s);
        public void Log(string msg)
        {
            if (msg == null)
                throw new ArgumentNullException ("msg");
            Global_Log(msg + Environment.NewLine);
        }
        public void Log(string msg, params object[] args)
        {
            if (msg == null)
                throw new ArgumentNullException ("msg");
            Global_Log(string.Format(msg + Environment.NewLine, args));
        }
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern string Global_GetLastError();
        public string GetLastError()
        {
            return Global_GetLastError();
        }
    }
}
