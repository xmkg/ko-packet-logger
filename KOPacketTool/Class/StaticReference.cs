/**
 * ______________________________________________________
 * This file is part of ko-packet-logger project.
 * 
 * @author       Mustafa Kemal Gılor <mustafagilor@gmail.com> (2015)
 * .
 * SPDX-License-Identifier:	MIT
 * ______________________________________________________
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace KOPacketTool.Class
{
  


    static class StaticReference
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow(string strClassName, string strWindowName);

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);

        public struct Rect
        {
            public int Left { get; set; }
            public int Top { get; set; }
            public int Right { get; set; }
            public int Bottom { get; set; }
        }

        public static List<byte> FilteredOpcodes = new List<byte>();
        public static long DatapackPtr { get; set; }
        public static long StaticBufferPtr { get; set; }

        public static void InsertFilterOpcode(byte b)
        {
            if (FilteredOpcodes.Contains(b))
                return;
            FilteredOpcodes.Add(b);

        }

        public static void RemoveFilterOpcode(byte b)
        {
            if (FilteredOpcodes.Contains(b))
                FilteredOpcodes.Remove(b);
        }

        public static void SaveFilterSettings()
        {
            byte[] array = FilteredOpcodes.ToArray();
            File.WriteAllBytes(".\\filter.bin", array);
        }

        public static void ReadFilterSettings()
        {
            try
            {
                byte[] array = File.ReadAllBytes(".\\filter.bin");
                if (array.Length > 0)
                {
                    foreach (byte b in array)
                    {
                        InsertFilterOpcode(b);
                    }
                }
            }
            catch (Exception)
            {
                
             /* ignored */
            }
        
          

        }
    }
}
