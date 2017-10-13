using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using AIC_Framework;
using AIC_Framework.Extensions;
using Console = AIC_Framework.AConsole;
using menu = AIC_Framework.AConsole.Menu;

namespace AICTest
{
    public class Kernel: Sys.Kernel
    {
        protected override void BeforeRun()
        {

            Bootscreen.Show("Welcome to Apollo OS", Bootscreen.Effect.SlideFromLeft, ConsoleColor.Blue, 1);
            Console.Clear();
            menu.Reset();
        }
        
        protected override void Run()
        {
            
            // Create a new category: catTest
            menu.Category catTest = new menu.Category("Test");
            catTest.AddEntry(new TestCommand());

            // Create a new category: catHello
            menu.Category catHello = new menu.Category("Hello");
            catHello.AddEntry(new HelloWorld());

            // Add the categories to the menu
            menu.AddCategory(catTest);
            menu.AddCategory(catHello);

            // Show the menu
            menu.Show();
        }
    }
    public class TestCommand : menu.Entry
    {
        public TestCommand() { this.text = "Test Command"; }
        public override void Execute()
        {
            Console.Clear();
            Console.WriteLine("Test command. Any method called here should work.");
            System.Console.ReadKey(true);
            Console.Clear();
            // Place the code that should be executed here
        }
    }

    // A hello world entry
    public class HelloWorld : menu.Entry
    {
        public HelloWorld() { this.text = "Hello World!"; }
        public override void Execute()
        {
            Console.Clear();
            AConsole.Write("Hello World!");
            Console.WriteLine("Press any key to continue...");
            System.Console.ReadKey(true);

            // Place the code that should be executed here
        }
    }
}
