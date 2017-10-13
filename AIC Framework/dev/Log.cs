/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2017, Apollo OS
Copyright (c) 2017, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.
*/

using System;
using System.Collections.Generic;

// That's the super secret dewitcher event log
namespace AIC_Framework.dev
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
            AConsole.VideoRAM.SetContent("__internal:logbackup");
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
