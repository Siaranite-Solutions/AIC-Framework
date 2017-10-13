/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2017, Apollo OS
Copyright (c) 2017, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.
*/

using System;
using System.Collections.Generic;

namespace AIC_Framework
{
    public unsafe static partial class AConsole
    {
        public static class VideoRAM
        {
            internal class VideoBuffer
            {
                public string id;
                public byte[] data;
                public int X, Y;
            }
            private static Stack<VideoBuffer> vbufferStack = new Stack<VideoBuffer>();
            private static List<VideoBuffer> vbufferList = new List<VideoBuffer>();
            /// <summary>
            /// Pushes what is in video RAM onto a stack
            /// </summary>
            public static void PushContents()
            {
                VideoBuffer vb = new VideoBuffer();
                byte* VideoRam = (byte*)0xB8000;
                vb.data = new byte[4250];
                for (int i = 0; i < 4250; i++)
                {
                    byte b = VideoRam[i];
                    vb.data[i] = b;
                }
                vb.X = AConsole.CursorLeft;
                vb.Y = CursorTop;
                vbufferStack.Push(vb);
            }
            /// <summary>
            /// Pops the content of the stack into Video RAM
            /// </summary>
            public static void PopContents()
            {
                VideoBuffer vb = vbufferStack.Pop();
                byte* VideoRam = (byte*)0xB8000;

                for (int i = 0; i < 4250; i++)
                {
                    VideoRam[i] = vb.data[i];

                }
                CursorLeft = vb.X;
                CursorTop = vb.Y;
            }
            /// <summary>
            /// Saves the Console content
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool SetContent(string name)
            {
                bool found = false;
                for (int i = 0; i < vbufferList.Count; i++)
                {
                    if (vbufferList[i].id == name)
                    {
                        found = true;
                        // Set new content
                        byte* vram = (byte*)0xB8000;
                        vbufferList[i].data = new byte[4250];
                        vbufferList[i].id = name;
                        for (int j = 0; j < 4250; j++)
                        {
                            byte b = vram[j];
                            vbufferList[i].data[j] = b;
                        }
                        vbufferList[i].X = CursorLeft;
                        vbufferList[i].Y = CursorTop;
                        return true;
                    }
                }
                if (!found)
                {
                    VideoBuffer vb = new VideoBuffer();
                    byte* vram = (byte*)0xB8000;
                    vb.data = new byte[4250];
                    vb.id = name;
                    for (int i = 0; i < 4250; i++)
                    {
                        byte b = vram[i];
                        vb.data[i] = b;
                    }
                    vb.X = AConsole.CursorLeft;
                    vb.Y = CursorTop;
                    vbufferList.Add(vb);
                    return true;
                }
                return false;
            }
            /// <summary>
            /// Restores the Console content
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
            public static bool RetContent(string name)
            {
                for (int i = 0; i < vbufferList.Count; i++)
                {
                    if (vbufferList[i].id == name)
                    {
                        // restore content
                        byte* vram = (byte*)0xB8000;
                        for (int j = 0; j < 4250; j++)
                        {
                            vram[j] = vbufferList[i].data[j];
                        }
                        CursorLeft = vbufferList[i].X;
                        CursorTop = vbufferList[i].Y;
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
