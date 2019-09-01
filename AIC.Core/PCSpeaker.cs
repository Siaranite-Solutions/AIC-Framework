/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2019, Siaranite Solutions
Copyright (c) 2019, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIC.Core.IO;

namespace AIC.Core
{
    public class PCSpeaker
    {
        public static void sound_on()
        {
            PortIO.outb(0x61, (byte)(PortIO.inb(0x61) | 3));
        }
        public static void sound_off()
        {
            PortIO.outb(0x61, (byte)(PortIO.inb(0x61) & ~3));
        }
        public static void Beep(uint frequency)
        {
            PIT.Beep(frequency);
            sound_on();
        }
        public static void Beep(uint frequency, uint milliseconds)
        {
            Beep(frequency);
            PIT.SleepMilliseconds(milliseconds);
            sound_off();
        }
        
    }
}
