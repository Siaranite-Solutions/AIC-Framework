/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2019, Siaranite Solutions
Copyright (c) 2019, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.
*/

using System;
using System.Collections.Generic;
using AIC_Framework;
using AIC.Core;

namespace AIC_Framework
{
    public static class Memory
    {
        public static void MemAlloc(uint length)
        {
            AIC.Core.Memory.MemAlloc(length);
        }
        public static void MemRemove(byte start, uint offset, uint length)
        {
            AIC.Core.Memory.MemRemove(start, offset, length);
        }
        public static void MemCopy(byte source, byte destination, uint offset, uint length)
        {
            AIC.Core.Memory.MemCopy(source, destination, offset, length);
        }
        public static void MemMove(byte source, byte destination, uint offset, uint length)
        {
            AIC.Core.Memory.MemMove(source, destination, offset, length);
        }
        public static  bool MemCompare(byte source1, byte source2, uint offset, uint length)
        {
            return AIC.Core.Memory.MemCompare(source1, source2, offset, length);
        }
    }
}
