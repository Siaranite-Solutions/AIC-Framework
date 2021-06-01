/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2019, Siaranite Solutions
Copyright (c) 2019, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.
*/

using System;
using System.Collections.Generic;
using C = AIC.Core.IO.PortIO;

namespace AIC.Main.dev
{
    public static class ATAPI
    {
        /* I/O Port */
        internal static ushort portnum;

        /* ATAPI_READTOC */
        internal static byte[] atapi_readtoc =
            new byte[] { 0x43 /* ATAPI_READTOC */, 0, 1, 0, 0, 0, 0, 0, 12, 0x40, 0, 0 };

        /* The default and seemingly universal sector size for CD-ROMs. */
        internal const int ATAPI_SECTOR_SIZE = 2048;

        /* The default ISA IRQ numbers of the ATA controllers. */
        internal const byte ATA_IRQ_PRIMARY = 0x0E;
        internal const byte ATA_IRQ_SECONDARY = 0x0F;

        /* The necessary I/O ports, indexed by "bus". */
        internal static ushort ATA_DATA = portnum; 
        internal static byte ATA_FEATURES = (byte)(portnum+(byte)1);
        internal static byte ATA_SECTOR_COUNT = (byte)(portnum+(byte)2);
        internal static byte ATA_ADDRESS1 = (byte)(portnum+(byte)3);
        internal static byte ATA_ADDRESS2 = (byte)(portnum+(byte)4);
        internal static byte ATA_ADDRESS3 = (byte)(portnum+(byte)5);
        internal static byte ATA_DRIVE_SELECT = (byte)(portnum+(byte)6);
        internal static byte ATA_COMMAND = (byte)(portnum+(byte)7);
        internal static ushort ATA_DCR = (byte)(portnum+0x206);

        /* valid values for "bus" */
        internal const short ATA_BUS_PRIMARY = 0x1F0;
        internal const short ATA_BUS_SECONDARY = 0x170;

        /* valid values for "drive" */
        internal const byte ATA_DRIVE_MASTER = 0xA0;
        internal const byte ATA_DRIVE_SLAVE = 0xB0;

        /* ATA specifies a 400ns delay after drive switching -- often
         * * implemented as 4 Alternative Status queries. */
        internal static void ATA_SELECT_DELAY(byte bus)
        {
            portnum = bus;
            C.inb(ATA_DCR);
            C.inb(ATA_DCR);
            C.inb(ATA_DCR);
            C.inb(ATA_DCR);
        }

        internal unsafe static int atapi_drive_read_sector(UInt32 bus, UInt32 drive, UInt32 lba, byte* buffer)
        {
            return AIC.Core.dev.ATAPI.atapi_drive_read_sector(bus, drive, lba, buffer);
        }
        /* Use the ATAPI protocol to read a single sector from the given
         * * bus/drive into the buffer using logical block address lba. 
        /*internal static unsafe int atapi_drive_read_sector(UInt32 bus, UInt32 drive, UInt32 lba, byte* buffer)
        {
            // 0xA8 is READ SECTORS command byte
            ushort[] read_cmd = new ushort[12] { 0xA8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            byte status;
            int size;

            // Tell the scheduler that this process is using the ATA subsystem
            // ata_grab(); // WHAT DA HELL IS ATA_GRAB()

            // Select drive (only the slave-bit is set)
            portnum = (byte)bus;
            ushort thePort = (ushort)(drive & (1 << 4));
            C.outb(thePort, ATA_DRIVE_SELECT);
            ATA_SELECT_DELAY((byte)bus); // 400ns delay
            C.outb(0x0, ATA_FEATURES); // PIO mode
            C.outb(ATAPI_SECTOR_SIZE & 0xFF, ATA_ADDRESS2);
            C.outb(ATAPI_SECTOR_SIZE >> 8, ATA_ADDRESS3);
            C.outb(0xA0, ATA_COMMAND); // ATA PACKET command

            // while ((status = inb (ATA_COMMAND (bus))) & 0x80)
            while (((status = C.inb(ATA_COMMAND)) & 0x80) == 0) {;}
            // while (!((status = inb (ATA_COMMAND (bus))) & 0x8) && !(status & 0x1))
            while (((status = C.inb(ATA_COMMAND)) & 0x8) != 0 && (status & 0x01) != 0) {;}

            // DRQ or ERROR set
            if ((byte)(status & 0x1) == 0)
            {
                size = -1;
                goto cleanup;
            }

            read_cmd[9] = 1; // 1 sector
            read_cmd[2] = (byte) ((lba >> 0x18) & 0xFF); // most sig. byte of LBA
            read_cmd[3] = (byte) ((lba >> 0x10) & 0xFF);
            read_cmd[4] = (byte) ((lba >> 0x08) & 0xFF);
            read_cmd[5] = (byte) ((lba >> 0x00) & 0xFF); // least sig. byte of LBA

            // Send ATAPI/SCSI command
            //outw(ATA_DATA, read_cmd);
            // WTF? read_cmd is an array!
            foreach (ushort ush in read_cmd) { C.outw(ATA_DATA, ush); }

            // Wait for IRQ that says the data is ready
            //schedule(); // ???

            // Read actual size
            size = (((int)C.inb(ATA_ADDRESS3)) >> 8) | (int)(C.inb(ATA_ADDRESS2));

            /* This code only supports the case where the data transfer
             * of one sector is done in one step. */
            // WHAT DA HELL IS ASSERT
            //ASSERT (size == ATAPI_SECTOR_SIZE);

            // Read data
            // inw((ushort)ATA_DATA, (ushort*)buffer, (ushort)(size / 2));

            /* The controller will send another IRQ even though we've read all
            * the data we want.  Wait for it -- so it doesn't interfere with
            * subsequent operations: */

            ////////////////////////////////////////////////////////////////
            // schedule(); // HAS SOMETHING TO DO WITH IRQ.. xD ////////////
            ////////////////////////////////////////////////////////////////

            /* Wait for BSY and DRQ to clear, indicating Command Finished 
            // while ((status = inb (ATA_COMMAND (bus))) & 0x88)
            while (((status = C.inb(ATA_COMMAND)) & 0x88) == 0) {;}

            cleanup:
                /* Exit the ATA subsystem 
                // ata_release(); // ATA RELEASE? WTF!!

            return size;*/
        }
}
