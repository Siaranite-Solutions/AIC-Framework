using System;
using System.Collections.Generic;
using System.Text;
using AIC_Framework;
using AIC_Framework.Extensions;
using Console = AIC_Framework.AConsole;
using menu = AIC_Framework.AConsole.Menu;

namespace AICTest
{
    public class ShutdownEntry : menu.Entry
    {
        public ShutdownEntry() { this.text = "Shutdown"; }
        public override void Execute()
        {
            Console.Clear();
            Console.WriteLine("Press any key to shutdown...");
            Console.ReadKey(true);
            userACPI.Shutdown();
        }
    }
    public class RebootEntry : menu.Entry
    {
        public RebootEntry() { this.text = "Reboot"; }
        public override void Execute()
        {
            Console.Clear();
            Console.WriteLine("Press any key to reboot...");
            Console.ReadKey(true);
            userACPI.Reboot();
        }
    }
    public class Entry1 : menu.Entry
    {
        public Entry1() { this.text = "Apollo Test Entry"; }
        public override void Execute()
        {
            Console.Clear();
            Console.WriteLine("Apollo Test Entry");
            Console.ReadKey(true);
            Console.Clear();
            // Place the code that should be executed here
        }
    }

    // A hello world entry
    public class Entry2 : menu.Entry
    {
        public Entry2() { this.text = "Hello, world! Test Entry"; }
        public override void Execute()
        {
            Console.Clear();
            Console.WriteLine("Hello World!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);

            // Place the code that should be executed here
        }
    }

    public class Bluescreen : menu.Entry
    {
        public Bluescreen() { this.text = "Bluescreen test"; }
        public override void Execute()
        {
            Console.Clear();
            Console.WriteLine("Press any key to start a test Stop Error");
            Console.ReadKey(true);
            try
            {
                System.IO.File.WriteAllText("WHAT", "LKJHSDLKFJHSD£^$&*£$");
            }
            catch (Exception ex)
            {
                AIC_Framework.Bluescreen.Init(ex, true);
                // Place the code that should be executed here
            }
        }
    }
}
