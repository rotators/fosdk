using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using main = FOnline.Main;
using System.Threading;

namespace FOnline
{
    class Player : GameType
    {
        public int Coins;
        public Player (Critter cr)
        {
            HandleGameType (cr);
        }
        public void AddItem(string whatever) 
        {
        }
    }
    class NukaColaMachine : GameType
    {
        public int AmountLeft { get; set; }
        public int CoinsInside { get; set; }
        private Item Machine { get; set; } // this is our native type used here, via composition and not inheritance

        public NukaColaMachine(int amount, int coins, Item machine)
        {
            this.AmountLeft = amount;
            this.CoinsInside = coins;

            this.Machine = machine;

            // now, the sweet part
            Event(Machine.Use(e =>
            {
                if(this.AmountLeft > 0) // we've got access to 'this' in event handler!
                {
                    // now, the bitter part, we've got only Critter reference of the 'user'
                    // so we need to use some special functionality to operate on game type
                    // that knows this critter, it's a way of sending a message
                    // "hey, execute this code if you're managed by Player gameplay class"
                    HandleGameType<Player>(e.Cr, p =>
                    {
                        if(p.Coins > 0)
                        {
                            p.Coins--;
                            AmountLeft--; // implicit this
                            CoinsInside++;
                            p.AddItem("PID_NUKACOLA");
                        }
                    });    
                }
            }));
        }
    }
    class Program
    {
		static void Init(object sender, EventArgs e)
		{
			Global.Log("Init from mono!");
            
			//Tests.InitRun ();

			Global.Log ("Done with tests.");
		}
        static void Main(string[] args)
        {
            var cr = new Critter (IntPtr.Zero);
            var item = new Item (IntPtr.Zero);

            var machine = new NukaColaMachine (10, 0, item);
            var player = new Player (cr);
            player.Coins = 100;

            item.RaiseUse (cr, null, null, IntPtr.Zero);
            Console.WriteLine (machine.CoinsInside);
            Console.WriteLine(machine.AmountLeft);

			main.Init += Init;
            if(args.Contains("-mono_repl"))
                main.Init += (o, e) => StartREPL();
            main.Start += (o, e) =>
            {
				//Tests.StartRun();
                Global.Log("Start from mono!");  
            };		
        }
        static void StartREPL()
        {
            var thread = new Thread(() =>
            {
                var repl = new REPL();
                repl.Process();
            });
            thread.Start();
        }
    }
}
