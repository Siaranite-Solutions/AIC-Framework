using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIC.Core
{
    public unsafe class Heap
    {
        public static void MemAlloc(uint length)
        {
            Cosmos.Core.Memory.Heap.Alloc(length);
        }
    }
    public class GetRAM
    {
        public static uint GetAmountOfRAM = Cosmos.Core.CPU.GetAmountOfRAM();
    }
}
