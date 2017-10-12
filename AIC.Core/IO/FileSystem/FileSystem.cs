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

//Disabling GLNFS as FAT is implemented. DetectDrives method may be implemented later.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIC.Core.IO.FileSystem
{
    public class FileSystem
    {
        public static VirtualFileSystem Root = new VirtualFileSystem(); // this is the root filesystem......
       
        public static void DetectDrives()
        {
            for (int i = 0; i < Cosmos.Hardware.BlockDevice.Partition.Devices.Count; i++)
            {
                if (Cosmos.Hardware.BlockDevice.Partition.Devices[i] is Cosmos.Hardware.BlockDevice.Partition)
                {
                    if(GruntyOS.HAL.GLNFS.isGFS(((Cosmos.Hardware.BlockDevice.Partition)Cosmos.Hardware.BlockDevice.BlockDevice.Devices[i])))
                    {
                        GruntyOS.HAL.GLNFS fs = new GruntyOS.HAL.GLNFS(((Cosmos.Hardware.BlockDevice.Partition)Cosmos.Hardware.BlockDevice.BlockDevice.Devices[i]));
                        Drive drv = new Drive();
                        GruntyOS.HAL.Devices.device dev = new GruntyOS.HAL.Devices.device();
                        Console.WriteLine("GLNFS PARTITION FOUND");
                        dev.name = @"?\\Harddrive\Partition" + i.ToString();
                        dev.dev = ((Cosmos.Hardware.BlockDevice.Partition)Cosmos.Hardware.BlockDevice.BlockDevice.Devices[i]);
                        drv.DeviceFile = dev.name;
                        GruntyOS.HAL.Devices.dev.Add(dev);
                        Root.AddDrive(drv);
                    }
                }
            }
        }
    }
}
*/