/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2017, Apollo OS
Copyright (c) 2017, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.
*/

using System;
using System.Collections.Generic;
// IDT code by Grunt
namespace AIC_Framework
{
    public class IDT
    {
        public delegate void ISR();
        public static ISR[] idt = new ISR[0xFF];
        public static void Remap()
        {
            AIC.Core.IDT.Remap();   
        }
        private void idt_handler()
        {
            AIC.Core.IDT.idt_handler();
        }

        public static void SetGate(byte int_num, ISR handler)
        {
            IDT.SetGate(int_num, handler);
        }

    }
}
