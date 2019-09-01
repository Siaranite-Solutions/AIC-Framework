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

namespace AIC_Framework
{
    public class userACPI
    {
        public static void Shutdown()
        {
            ACPI.Shutdown();
        }
        public static void Reboot()
        {
            ACPI.Reboot();
        }
    }
}