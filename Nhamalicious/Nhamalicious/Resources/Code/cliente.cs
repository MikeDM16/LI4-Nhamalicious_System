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
using Xamarin.Android;
using System.Net.Sockets;
using NhamiBackEnd1.Code;
using System.Net;

namespace Nhamalicious.Resources.Code
{
    class Cliente
    {
        static Socket clientSocket;

        public Cliente()
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        //public PacoteLogin LoginAtempt(string username, string password)
        //{
        //    PacoteLogin ret;

        //    try
        //    {
        //        clientSocket.Connect(IPAddress.Parse("188.37.222.50"), 3333);
        //    }
        //    catch (SocketException ex)
        //    {
                    
        //    }
        //    catch (ObjectDisposedException ex)
        //    {
                
        //    }

        //    r/*eturn ret;*/
        //}
    }
}