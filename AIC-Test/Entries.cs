using System;
using System.Collections.Generic;
using System.Text;
using AIC.Main;
using AIC.Main.Extensions;
using Console = AIC.Main.AConsole;
using menu = AIC.Main.AConsole.Menu;

namespace AICTest
{
    public class ShutdownEntry : menu.Entry
    {
        public ShutdownEntry() { this.text = "Shutdown"; }
        public override void Execute()
        {
            Console.Clear();
            KernelExtensions.PressAnyKey("Press any key to shutdown...");
            userACPI.Shutdown();
        }
    }
    public class RebootEntry : menu.Entry
    {
        public RebootEntry() { this.text = "Reboot"; }
        public override void Execute()
        {
            Console.Clear();
            KernelExtensions.PressAnyKey("Press any key to reboot...");
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
            KernelExtensions.PressAnyKey();
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
            KernelExtensions.PressAnyKey();
            Console.Clear();
            // Place the code that should be executed here
        }
    }

    public class Bluescreen : menu.Entry
    {
        public Bluescreen() { this.text = "Bluescreen test"; }
        public override void Execute()
        {
            Console.Clear();
            KernelExtensions.PressAnyKey("Press any key to start a test Stop Error");
            try
            {
                int a = 0;
                int b = 10;
                Console.WriteLine((b / a).ToString());
            }
            catch (Exception ex)
            {
                AIC.Main.Bluescreen.Init(ex, true);
                // Place the code that should be executed here
            }
            Console.Clear();
        }
    }

    public class CryptoSHA256 : menu.Entry
    {
        public CryptoSHA256() { this.text = "SHA256 Test"; }

        public override void Execute()
        {
            Console.WriteLine("Enter string to be hashed using SHA256");
            StringExtensions.SHA256(Console.ReadLine());
            Console.Clear();
        }
    }
}
