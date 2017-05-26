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

namespace Nhamalicious.Resources.Code
{
    class PedidoCli
    {
        static Socket clientSocket;

        public PedidoCli()
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public PacoteLogin LoginAtempt(string username, string password)
        {
            PacoteLogin ret = null;

            try
            {
                clientSocket.Connect(IPAddress.Parse("94.61.37.44"), 3333);
                if (clientSocket.Connected)
                {
                    Utilizador u = new Utilizador(username, password);
                    ret = new PacoteLogin(u, "login");
                    Envelope env = new Envelope(PacoteType.Login, ret);
                    byte[] enviar = env.ToByteArray();
                    clientSocket.Send(enviar);
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