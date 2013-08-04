using System;
using FOnline;
using Microsoft.CSharp.RuntimeBinder;

namespace FOnline
{
    public static class Tests
    {
        static int counter = 0;
        static int total = 0;
        public static void Assert(bool cond, string msg)
        {
            total++;
            if(cond)
            {
                counter++;
                Global.Log ("{0} passed.", msg);
            }
            else
                Global.Log ("{0} failed.", msg);
        }
        public static void asAssert(bool cond, IntPtr msg)
        {
            throw new NotSupportedException ();
        }
        public static void InitRun()
        {
            Global.Log ("Running tests...");
            counter = total = 0;
            
            try 
            {
            }
            finally
            {
                Global.Log("{0} succeeded out of {1}.", counter, total);
            }
        }
        public static void StartRun()
        {
            Global.Log("Running tests...");
            //counter = total = 0;
            
            try
            {
                MemoryTests.Run ();
            }
            finally
            {
                Global.Log("{0} succeeded out of {1}.", counter, total);
            }
        }
    }

    public static class MemoryTests
    {
        static void Collect()
        {
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
            Global.CollectScriptGarbage();
        }
        
        static Critter GetCritter()
        {
            return Global.GetCritter(5000003);
        }
        public static void CritterFromNative()
        {
            var cr = GetCritter();
            int rc = cr.RefCount;
            var ncr = (Critter)cr.ThisPtr; // this does not create new Critter object, so rc stays same
            Tests.Assert (cr.RefCount == rc, "RC unchanged.");
            ncr = null;
            Collect ();
            Tests.Assert(cr.RefCount == rc, "RC unchanged.");
        }
        public static void Run()
        {
            CritterFromNative();
        }
    }
}

