/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2019, Siaranite Solutions
Copyright (c) 2019, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.
*/

using System;
using AIC.Main;
using AIC.Core;
using IO = AIC.Core.IO;

namespace AIC.Main
{
    public static class PIT
    {
        public static void Mode0(uint frequency)
        {
            AIC.Core.PIT.Mode0(frequency);
        }
        public static void Mode2(uint frequency)
        {
            AIC.Core.PIT.Mode2(frequency);
        }
        public static void Beep(uint frequency)
        {
            AIC.Core.PIT.Beep(frequency);
        }
        internal static bool called = false;
        public static void SleepSeconds(uint seconds)
        {
            SleepMilliseconds(seconds * 1000);
        }
        public static void SleepMilliseconds(uint milliseconds)
        {
            AIC.Core.PIT.SleepMilliseconds(milliseconds);
        }
    }
}
