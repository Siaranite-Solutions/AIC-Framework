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

// That's the super secret dewitcher event log
namespace dewitcher2.dev
{
    public static class Log
    {
        private static bool initialized = false;
        private static List<string> cc, cg, ds;
        /// <summary>
        /// Please use the following formatting for callingclass:
        /// dewitcher.[namespace/s].[class].[method/function]
        /// For example: dewitcher.dev.testclass.amethod
        /// </summary>
        /// <param name="callingclass">For example: dewitcher.dev.testclass.amethod</param>
        /// <param name="category">The category, for example WitchFS</param>
        /// <param name="description">The event description</param>
        public static void AddEntry(string callingclass, string category, string description)
        {
            if (!initialized) init();
            cc.Add(callingclass);
            cg.Add(category);
            ds.Add(description);
        }
        public static void GetEntries(string category)
        {
            if (!initialized) init();
            // Save current console state
            KConsole.VideoRAM.SetContent("__internal:logbackup");
            // Write the entries
            int max = Console.WindowHeight - 4;
            int found = 0;
            bool finished = false;
            while (!finished)
            {
                if (found < cc.Count)
                {
                    for (int i = found; i < cc.Count; i++)
                    {

                    }
                }
            }
        }
        public static void Test()
        {
            AddEntry("dewitcher.dev.Log.crap", "crap", "that's some crap");
            AddEntry("dewitcher.dev.Log.crap", "crap", "that's some crap too");
            AddEntry("dewitcher.dev.Log.crap", "crap", "that's some crap loo");
            AddEntry("dewitcher.dev.Log.crap", "crap", "that's some crap =P");
            AddEntry("dewitcher.dev.Log.crap", "crap", "that's some crap yeah");
            AddEntry("dewitcher.dev.Log.crap", "crap", "that's some crappppppp");
            GetEntries("crap");
        }
        private static void init()
        {
            cc = new List<string>();
            cg = new List<string>();
            ds = new List<string>();
            initialized = true;
        }
    }
}
