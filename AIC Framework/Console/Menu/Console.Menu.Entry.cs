/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2017, Apollo OS
Copyright (c) 2017, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.
*/

using System;

namespace AIC_Framework
{
    public static partial class AConsole
    {
        public partial class Menu
        {
            public abstract class Entry
            {
                public string text;
                public abstract void Execute();
            }
        }
    }
}
