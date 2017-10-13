/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2017, Apollo OS
Copyright (c) 2017, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.
*/

using System;
using AIC_Framework;
using AIC.Core;
using IO = AIC.Core.IO;

namespace AIC_Framework
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
            uint divisor = 1193182 / frequency;
            AIC.Core.IO.PortIO.outb(0x43, 0xB6);
            AIC.Core.IO.PortIO.outb(0x42, (byte)(divisor & 0xFF));
            AIC.Core.IO.PortIO.outb(0x42, (byte)((divisor >> 8) & 0xFF));
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
