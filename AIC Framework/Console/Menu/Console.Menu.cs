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

namespace AIC_Framework
{
    public static partial class AConsole
    {
        public partial class Menu
        {
            public static bool recovery = false;
            public static int menu = 0;
            public static List<AConsole.Menu.Category> cat;
            public static ConsoleColor fill;
            public static ConsoleColor background;
            public static ConsoleColor normal;
            public static ConsoleColor highlighted;
            public static ConsoleColor arrow;
            internal static int item = 0;
            internal static int itemcat = 0;
            public static void Reset()
            {
                cat.Clear();
                cat = new List<AConsole.Menu.Category>();
                fill = ConsoleColor.Cyan;
                background = ConsoleColor.Green;
                normal = ConsoleColor.Black;
                highlighted = ConsoleColor.White;
                arrow = ConsoleColor.Yellow;
            }
            public static void ApplyThemePack(ConsoleColor[] colors)
            {
                if (colors.Length == 5)
                {
                    fill = colors[0];
                    background = colors[1];
                    normal = colors[2];
                    highlighted = colors[3];
                    arrow = colors[4];
                }
                else if (colors.Length < 5)
                    AIC_Framework.Bluescreen.Init("INVALID_THEME_EXCEPTION",
                    "Looks like your ConsoleColor-Array contains less than 5 entries");
                else if (colors.Length > 5)
                    AIC_Framework.Bluescreen.Init("INVALID_THEME_EXCEPTION",
                    "Looks like your ConsoleColor-Array contains more than 5 entries");
            }
            public static void AddCategory(AConsole.Menu.Category category) { cat.Add(category); }
            public static void Show()
            {
                System.Console.Clear();
                AConsole.Fill(fill);
                while (true)
                {
                    if (recovery) break;
                    if (menu == 0) ShowCategoryMenu();
                    else if (menu == 1) { AConsole.Fill(fill); menu++; }
                    else if (menu == 2) ShowEntryMenu();
                    else if (menu == 3) { AConsole.Fill(fill); menu = 0; }
                }
            }
            private static void ShowCategoryMenu()
            {
                for (int i = 10 - (cat.Count / 2); i < 11 + cat.Count; i++)
                {
                    string buffer = "";
                    AConsole.CursorTop = i;
                    for (int j = 10; j <= 70; j++)
                    {
                        buffer += " ";
                    }
                    AConsole.CursorLeft = 10;
                    AConsole.WriteEx(buffer, background, background);
                }
                AConsole.CursorTop = 11 - (cat.Count / 2);
                for (int i = 0; i < cat.Count; i++)
                {
                    if (i == item)
                    {
                        AConsole.WriteEx(cat[i].Name, highlighted, background, true);
                        AConsole.CursorLeft = 69;
                        AConsole.WriteLineEx(">", arrow, background);
                    }
                    else AConsole.WriteLineEx(cat[i].Name, normal, background, true);
                }
                while (true)
                {
                    ConsoleKey key = AConsole.ReadKey().Key;
                    if (key == ConsoleKey.UpArrow)
                    {
                        if (item > 0) item--;
                        else item = cat.Count - 1;
                        break;
                    }
                    else if (key == ConsoleKey.DownArrow)
                    {
                        if (item < cat.Count - 1) item++;
                        else item = 0;
                        break;
                    }
                    else if (key == ConsoleKey.Enter || key == ConsoleKey.RightArrow)
                    {
                        itemcat = item;
                        item = 0;
                        menu = 1;
                        break;
                    }
                }
            }
            private static void ShowEntryMenu()
            {
                for (int i = 10 - (cat[itemcat].entries.Count / 2); i < 11 + cat.Count; i++)
                {
                    string buffer = "";
                    AConsole.CursorTop = i;
                    for (int j = 10; j <= 70; j++)
                    {
                        buffer += " ";
                    }
                    AConsole.CursorLeft = 10;
                    AConsole.WriteEx(buffer, background, background);
                }
                AConsole.CursorTop = 11 - (cat[itemcat].entries.Count / 2);
                for (int i = 0; i < cat[itemcat].entries.Count; i++)
                {
                    if (i == item)
                    {
                        AConsole.WriteEx(cat[itemcat].entries[i].text, highlighted, background, true);
                        AConsole.CursorLeft = 69;
                        AConsole.WriteLineEx(">", arrow, background);
                    }
                    else AConsole.WriteLineEx(cat[itemcat].entries[i].text, normal, background, true);
                }
                while (true)
                {
                    ConsoleKey key = AConsole.ReadKey().Key;
                    if (key == ConsoleKey.UpArrow)
                    {
                        if (item > 0) item--;
                        else item = cat[itemcat].entries.Count - 1;
                        break;
                    }
                    else if (key == ConsoleKey.DownArrow)
                    {
                        if (item < cat[itemcat].entries.Count - 1) item++;
                        else item = 0;
                        break;
                    }
                    else if (key == ConsoleKey.Enter || key == ConsoleKey.RightArrow)
                    {
                        cat[itemcat].entries[item].Execute();
                        break;
                    }
                }
            }
        }
    }
}