/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2019, Siaranite Solutions
Copyright (c) 2019, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.
*/

using System;
using System.Text;
using AIC.Core;

namespace AIC.Main
{
    public class userACPI
    {
        public static void Shutdown()
        {
            Cosmos.System.Power.Shutdown();
        }
        public static void Reboot()
        {
            Cosmos.System.Power.Reboot();
        }
    }
}