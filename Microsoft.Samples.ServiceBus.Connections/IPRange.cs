//---------------------------------------------------------------------------------
// Microsoft (R) .NET Services 
// 
// Copyright (c) Microsoft Corporation. All rights reserved.  
//
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
//---------------------------------------------------------------------------------

namespace Microsoft.Samples.ServiceBus.Connections
{
    using System;
    using System.Net;

    public class IPRange
    {
        UInt32 begin;
        UInt32 end;

        public IPRange(IPAddress address)
        {
            if (address.AddressFamily != System.Net.Sockets.AddressFamily.InterNetwork)
            {
                throw new ArgumentException("only IPv4 addresses permitted", "address");
            }
            this.begin = this.end = IPAddressToInt(address);
        }

        public IPRange(IPAddress begin, IPAddress end)
        {
            if (begin.AddressFamily != System.Net.Sockets.AddressFamily.InterNetwork)
            {
                throw new ArgumentException("only IPv4 addresses permitted", "begin");
            }
            if (end.AddressFamily != System.Net.Sockets.AddressFamily.InterNetwork)
            {
                throw new ArgumentException("only IPv4 addresses permitted", "end");
            }
            this.begin = IPAddressToInt(begin);
            this.end = IPAddressToInt(end);
        }

        public bool IsInRange(IPAddress address)
        {
            UInt32 ad = IPAddressToInt(address);
            return (this.begin <= ad && this.end >= ad);
        }

        UInt32 IPAddressToInt(IPAddress address)
        {
            byte[] ab = address.GetAddressBytes();
            UInt32 result = (((UInt32)ab[0] << 24) + ((UInt32)ab[1] << 16) + ((UInt32)ab[2] << 8) + ab[3]);
            return result;
        }
    }
}
