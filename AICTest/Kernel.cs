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

            Bootscreen.Show("Welcome to the AIC Framework test project!", Bootscreen.Effect.Matrix, ConsoleColor.Green, 5);
            Console.Clear();
            menu.Reset();
        }
        
        protected override void Run()
        {
            
            // Create a new category: catTest
            menu.Category catTest = new menu.Category("Category 1");
            catTest.AddEntry(new Entry1());
            catTest.AddEntry(new Entry2());
            // Create a new category: catAICTests
            // Contains methods for testing the AIC Framework.
            menu.Category catAICTests = new menu.Category("Power menu");
            catAICTests.AddEntry(new ShutdownEntry());
            catAICTests.AddEntry(new RebootEntry());

            // Add the categories to the menu
            menu.AddCategory(catTest);
            menu.AddCategory(catAICTests);

            // Show the menu
            menu.Show();
            
        }
    }

}
