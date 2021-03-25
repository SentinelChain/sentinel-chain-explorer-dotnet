using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SentinelChain
{
    public struct TransferAndCallDataInput
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string serialNo;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string entryPointId;

        public byte[] GetBytes(TransferAndCallDataInput str)
        {
            int size = Marshal.SizeOf(str);
            byte[] arr = new byte[size];

            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(str, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return arr;
        }
    }
}
