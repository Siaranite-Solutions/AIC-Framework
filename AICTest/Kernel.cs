using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using AIC_Framework;
using AIC_Framework.Extensions;
using Console = AIC_Framework.AConsole;

namespace AICTest
{
    public class Kernel: Sys.Kernel
    {
        protected override void BeforeRun()
        {

            Bootscreen.Show("Welcome to Apollo OS", Bootscreen.Effect.Matrix, ConsoleColor.Blue, 5);
            Console.Clear();
        }
        
        protected override void Run()
        {
            Console.Write("Input: ");
            var input = Console.ReadLine();
            Console.Write("Text typed: ");
            Console.WriteLine(input);
        }
    }
}
