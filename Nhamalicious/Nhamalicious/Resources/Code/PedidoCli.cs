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

        //    public void ConnectToServer()
        //    {
        //        while (!clientSocket.Connected)
        //        {
        //            try
        //            {
        //                clientSocket.BeginConnect(endPoint, ConnectCallback, null);
        //            }
        //            catch (SocketException)
        //            {
        //                return;
        //            }
        //        }
        //    }
        //    private void ReceiveCallback(IAsyncResult AR)
        //    {
        //        try
        //        {
        //            int received = clientSocket.EndReceive(AR);

        //            if (received == 0)
        //            {
        //                return;
        //            }


        //            string message = Encoding.ASCII.GetString(buffer);

        //            Invoke((Action)delegate
        //            {
        //                Text = "Server says: " + message;
        //            });

        //            Start receiving data again.
        //            clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveCallback, null);
        //        }
        //         Avoid Pokemon exception handling in cases like these.
        //        catch (SocketException ex)
        //        {
        //            ShowErrorDialog(ex.Message);
        //        }
        //        catch (ObjectDisposedException ex)
        //        {
        //            ShowErrorDialog(ex.Message);
        //        }
        //    }

        //    private void ConnectCallback(IAsyncResult AR)
        //    {
        //        try
        //        {
        //            clientSocket.EndConnect(AR);
        //        }
        //        catch (SocketException ex)
        //        {
        //            ShowErrorDialog(ex.Message);
        //        }
        //        catch (ObjectDisposedException ex)
        //        {
        //            ShowErrorDialog(ex.Message);
        //        }
        //    }

        //    private void SendCallback(IAsyncResult AR)
        //    {
        //        try
        //        {
        //            clientSocket.EndSend(AR);
        //        }
        //        catch (SocketException ex)
        //        {
        //            ShowErrorDialog(ex.Message);
        //        }
        //        catch (ObjectDisposedException ex)
        //        {
        //            ShowErrorDialog(ex.Message);
        //        }
        //    }

        //    public PacoteLogin LoginAtempt(string username, string password)
        //    {
        //        PacoteLogin ret = null;

        //        try
        //        {
        //            if (clientSocket.Connected)
        //            {
        //                Utilizador u = new Utilizador(username, password);
        //                ret = new PacoteLogin(u, "login");
        //                AMessage sending = Serializer.Serialize(ret);
        //                clientSocket.Send(sending.Data);
        //            }
        //        }
        //        catch (SocketException ex)
        //        {

        //        }
        //        catch (ObjectDisposedException ex)
        //        {

        //        }

        //        return ret;
        //    }
    }
}