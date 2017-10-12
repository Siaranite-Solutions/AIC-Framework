/*
Copyright (c) 2012-2013, dewitcher Team
All rights reserved.

Redistribution and use in source and binary forms, with or without modification,
are permitted provided that the following conditions are met:

* Redistributions of source code must retain the above copyright notice
   this list of conditions and the following disclaimer.

* Redistributions in binary form must reproduce the above copyright notice,
  this list of conditions and the following disclaimer in the documentation
  and/or other materials provided with the distribution.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR
IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR
CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER
IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF
THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

using System;
using System.Collections.Generic;
using AIC_Framework;
using AIC.Core;

namespace AIC_Framework
{
    public static class Bluescreen
    {
        /// <summary>
        /// Initiates a Bluescreen.
        /// </summary>
        /// <param name="error">Error title or exception name</param>
        /// <param name="description">Error description</param>
        /// <param name="critical">Critical error?</param>
        public static void Init(
            string error = "Something went wrong!",
            string description = "Unknown exception",
            bool critical = false)
        {
            DrawOOPS();
            if (description.Length + 33 < System.Console.WindowHeight)
            {
                System.Console.CursorTop = 2; System.Console.CursorLeft = 33;
                ConsoleColor errcolor = ConsoleColor.White;
                if (critical) errcolor = ConsoleColor.Red;
                AConsole.WriteLineEx(error, errcolor, ConsoleColor.Blue);
                AConsole.CursorTop = 4; AConsole.CursorLeft = 70;
                AConsole.WriteLineEx(description, ConsoleColor.White, ConsoleColor.Blue);
            }
            else
            {
                AConsole.CursorTop = 12; AConsole.CursorLeft = 2;
                ConsoleColor errcolor = ConsoleColor.White;
                if (critical) errcolor = ConsoleColor.Red;
                AConsole.WriteLineEx(error, errcolor, ConsoleColor.Blue);
                AConsole.CursorTop = 14; AConsole.CursorLeft = 2;
                AConsole.WriteLineEx(description, ConsoleColor.White, ConsoleColor.Blue);
            }
            if (!critical)
            {
                AConsole.CursorTop = AConsole.WindowHeight - 1;
                AConsole.WriteEx("Press the [Enter]-key to resume", ConsoleColor.White, ConsoleColor.Blue);
                AConsole.CursorTop++;
                AConsole.ReadLine();
                AConsole.Clear();
            }
            else
            {
                AConsole.CursorTop = AConsole.WindowHeight - 4;
                AConsole.WriteLineEx("Press the [Enter]-key to shutdown", ConsoleColor.White, ConsoleColor.Blue);
                AConsole.CursorTop++;
                AConsole.WriteLineEx("If it doesn't work, press the RESET-button on your computer.", ConsoleColor.White, ConsoleColor.Blue);
                AConsole.CursorTop++;
                AConsole.ReadLine();
                ACPI.Shutdown();
            }
        }
        public static void Init(Exception ex, bool critical = false)
        {
            DrawOOPS();
            if (ex.Message.Length + 33 < AConsole.WindowHeight)
            {
                AConsole.CursorTop = 2; AConsole.CursorLeft = 33;
                ConsoleColor errcolor = ConsoleColor.White;
                if (critical) errcolor = ConsoleColor.Red;
                AConsole.WriteLineEx(ex.Source, errcolor, ConsoleColor.Blue);
                AConsole.CursorTop = 4; AConsole.CursorLeft = 70;
                AConsole.WriteLineEx(ex.Message, ConsoleColor.White, ConsoleColor.Blue);
            }
            else
            {
                AConsole.CursorTop = 12; AConsole.CursorLeft = 2;
                ConsoleColor errcolor = ConsoleColor.White;
                if (critical) errcolor = ConsoleColor.Red;
                AConsole.WriteLineEx(ex.Source, errcolor, ConsoleColor.Blue);
                AConsole.CursorTop = 14; AConsole.CursorLeft = 2;
                AConsole.WriteLineEx(ex.Message, ConsoleColor.White, ConsoleColor.Blue);
            }
            if (!critical)
            {
                AConsole.CursorTop = AConsole.WindowHeight - 3;
                AConsole.WriteEx("Press the [Enter]-key to resume", ConsoleColor.White, ConsoleColor.Blue);
                AConsole.CursorTop++;
                AConsole.ReadLine();
                AConsole.Clear();
            }
            else
            {
                AConsole.CursorTop = AConsole.WindowHeight - 4;
                AConsole.WriteEx("Press the [Enter]-key to shutdown", ConsoleColor.White, ConsoleColor.Blue);
                AConsole.CursorTop++;
                AConsole.WriteEx("If it doesn't work, press the RESET-button on your computer.", ConsoleColor.White, ConsoleColor.Blue);
                AConsole.CursorTop++;
                AConsole.ReadLine();
                ACPI.Shutdown();
            }
        }
        private static void DrawOOPS()
        {
            AConsole.Fill(ConsoleColor.Blue);
            string[] arrOOPS = new string[] {
                "======  ======  =====  =====  =",
                "=    =  =    =  =   =  =      =",
                "=    =  =    =  =====  =====  =",
                "=    =  =    =  =          =   ",
                "======  ======  =      =====  ="};
            AConsole.CursorTop = 2;
            foreach (string str in arrOOPS)
            {
                AConsole.CursorLeft = 2;
                AConsole.WriteLineEx(str, ConsoleColor.White, ConsoleColor.Blue);
            }
        }
        /// <summary>
        /// Kernel Panic
        /// </summary>
        public static void Panic()
        {
            AConsole.Clear();
            AConsole.Fill(ConsoleColor.Red);
            AConsole.CursorTop = 2;
            AConsole.WriteLineEx("KERNEL PANIC", ConsoleColor.White, ConsoleColor.Red, true);
            AConsole.WriteLine("\n");
            string message = "CRITICAL KERNEL EXCEPTION\nPLEASE CONTACT YOUR SOFTWARE MANUFACTURER";
            AConsole.WriteLineEx(message, ConsoleColor.White, ConsoleColor.Red, true);
            // Enter an infinite loop
            while (true)
            {

            }
        }
    }
}
