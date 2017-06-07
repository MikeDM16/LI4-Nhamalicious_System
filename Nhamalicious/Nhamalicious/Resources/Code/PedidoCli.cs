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
using System.Net;
using ClassesPartilhadas;
using ClassesPartilhadas.Classes;

namespace Nhamalicious.Resources.Code
{
    class PedidoCli
    {
        static Socket clientSocket;

        public PedidoCli()
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        }

        public void ConnectToServer()
        {
            clientSocket.Connect(IPAddress.Parse(GetLocalIPAddress()), 3333);
        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }
        public PacoteLogin LoginAtempt(string username, string password)
        {
            PacoteLogin ret = null;

            try
            {
                if (clientSocket.Connected)
                {
                    Utilizador u = new Utilizador(username, password);
                    ret = new PacoteLogin(u, "login");
                    AMessage sending = Serializer.Serialize(ret);
                    clientSocket.Send(sending.Data);
                }
            }
            catch (SocketException ex)
            {

            }
            catch (ObjectDisposedException ex)
            {

            }

            return ret;
        }
    }
}