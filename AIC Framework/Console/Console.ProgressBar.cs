/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2017, Apollo OS
Copyright (c) 2017, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIC_Framework
{
    public static partial class AConsole
    {
        public class ProgressBar
        {
            private bool flicker = true;
            private int value = 0;
            public int Value
            {
                get { return value; }
                set
                {
                    if (value >= 0 && value <= 100)
                    {
                        this.value = value;
                    }
                }
            }
            /// <summary>
            /// Initialize a new ProgressBar
            /// </summary>
            /// <param name="startValue">Value</param>
            /// <param name="Flicker">true = Very cool effect =)</param>
            public ProgressBar(int startValue, bool Flicker = false)
            {
                this.Value = startValue;
                this.flicker = Flicker;
                this.Refresh();
            }
            public void Increment()
            {
                this.Value++;
                this.Refresh();
            }
            public void Decrement()
            {
                this.Value--;
                this.Refresh();
            }
            /// <summary>
            /// INFO: MaxValue is 100 and MinValue is 0.
            /// </summary>
            /// <param name="value"></param>
            public void Draw()
            {
                int ct = AConsole.CursorTop;
                int cl = AConsole.CursorLeft;
                AConsole.WriteLine();
                string buffer = "[                                                  ] ";
                AConsole.Write(buffer);
                AConsole.CursorLeft = cl + 1;
                if (flicker)
                {
                    for (int i = 0; i < this.value / 2; i++)
                    {
                        if (this.value / 2 <= 50) AConsole.Write("=");
                    }
                }
                else
                {
                    string __buffer = "";
                    for (int i = 0; i < this.value / 2; i++)
                    {
                        if (this.value / 2 <= 50) __buffer += "=";
                    }
                    AConsole.Write(__buffer);
                }
                AConsole.CursorLeft = cl + 54;
                AConsole.Write(this.value.ToString() + "%");
                AConsole.CursorTop = ct;
                AConsole.CursorLeft = cl;
            }
            private void Refresh()
            {
                this.Draw();
            }
        }
    }
}
