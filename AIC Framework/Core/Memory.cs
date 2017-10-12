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
