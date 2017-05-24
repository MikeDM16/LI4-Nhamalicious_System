using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net.Sockets;
using System.Net;

namespace Nhamalicious.Resources.Code
{
    class Cliente
    {
        static Socket sending = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public static void Run()
        {

            sending.Connect(new IPEndPoint(IPAddress.Parse("193.137.92.87"), 80));
        }

    }
}