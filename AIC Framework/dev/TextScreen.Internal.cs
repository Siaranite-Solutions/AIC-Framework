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
using System.Linq;
using System.Text;
using C = dewitcher2.Core.IO.PortIO;

namespace dewitcher.dev
{
    public partial class TextScreen
    {
        public static Color Foreground, Background;
        public static int X, Y;
        public enum Color : byte
        {
            Black = 0x0,
            Blue = 0x1,
            Green = 0x2,
            Cyan = 0x3,
            Red = 0x4,
            Magenta = 0x5,
            Brown = 0x6,
            Lightgray = 0x7,
            Gray = 0x8,
            Lightblue = 0x9,
            Lightgreen = 0xA,
            Lightcyan = 0xB,
            Lightred = 0xC,
            Lightmagenta = 0xD,
            Yellow = 0xE,
            White = 0xF
        }
        public static unsafe void PrintChar(char chr, int x, int y)
        {
            //int* port = (int*)0xB8000;
            //port += (int)(((byte)color << 8) | chr);
            byte* address = (byte*)0xB8000;
            int position = (y * 80) + x;
            address[position] = (byte)chr;
            address[++position] = (byte)((uint)(Foreground) | ((uint)(Background) << 4));
            if (x < 80) { X = x; X++; }
            else { X = 0; Y = y; Y++; }
        }
        internal static int GetOffset(int X, int Y)
        {
            return Y * 80 + X;
        }
        public static void UpdateCursor(int X, int Y)
        {
            int tmp = GetOffset(X, Y);
            C.outb(0x3D4, 14);
            C.outb(0x3D5, (byte)(tmp >> 8));
            C.outb(0x3D4, 15);
            C.outb(0x3D5, (byte)tmp);
        }
        public static void RemoveCursor()
        {
            C.outb(0x3D4, 14);
            C.outb(0x3D5, 0x07);
            C.outb(0x3D4, 15);
            C.outb(0x3D5, 0xD0);
        }
    }
}
