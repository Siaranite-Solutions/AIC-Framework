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
using Cosmos.HAL;

namespace AIC_Framework
{
    // INFO: We recommend to set the keylayout in the BeforeRun() method to make sure that
    //       the arrow keys does not appear as a pretty fuckedup random unicode char..
    public static class KeyLayout
    {
        internal static List<Cosmos.System.KeyMapping> keys;
        public enum KeyLayouts : byte { QWERTY, QWERTZ, AZERTY };
        private static uint KeyCount;
        private static void ChangeKeyMap()
        {
            AIC.Hardware.KeyLayout.ChangeKeyMap("QWERTY");
        }
        public static void SwitchKeyLayout(KeyLayouts layout)
        {
            switch (layout)
            {
                case KeyLayouts.AZERTY:
                    AZERTY(); break;
                case KeyLayouts.QWERTY:
                    QWERTY(); break;
                case KeyLayouts.QWERTZ:
                    QWERTZ(); break;
            }
        }
        private static void AddKey(uint p, char p_2, ConsoleKey p_3)
        {
            throw new NotImplementedException();
            //keys.Add(new Cosmos.System.KeyMapping(p, p_2, p_3));
            //KeyCount += 1u;
        }
        private static void AddKeyWithShift(uint p, char p_2, ConsoleKey p_3)
        {
            AddKey(p, p_2, p_3);
            AddKey(p << 16, p_2, p_3);
        }
        private static void AddKey(uint p, ConsoleKey p_3)
        {
            AddKey(p, '\0', p_3);
        }
        private static void AddKeyWithShift(uint p, ConsoleKey p_3)
        {
            AddKeyWithShift(p, '\0', p_3);
        }
        public static void QWERTY()
        {
            AIC.Hardware.KeyLayout.QWERTY();
            ChangeKeyMap();
        }

        /// <summary>
        /// The QWERTZ-Implementation is not 100% finished.
        /// Most keys will work, some keys will still return QWERTY-Chars.
        /// </summary>
        public static void QWERTZ()
        {
            AIC.Hardware.KeyLayout.QWERTZ();
            ChangeKeyMap();
        }

        public static void AZERTY()
        {
            AIC.Hardware.KeyLayout.AZERTY();
            ChangeKeyMap();
        }
    }
}