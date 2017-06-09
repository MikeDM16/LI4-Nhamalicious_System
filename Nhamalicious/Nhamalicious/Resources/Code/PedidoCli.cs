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
using SharedClasses;

namespace Nhamalicious.Resources.Code
{
    class PedidoCli
    {
        static Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        AMessage am;

        public void ConnectToServer()
        {
            int attempts = 0;

            while (!clientSocket.Connected)
            {
                try
                {
                    attempts++;
                    // Change IPAddress.Loopback to a remote IP to connect to a remote host.
                    clientSocket.Connect("10.0.2.2", 3333);
                }
                catch (SocketException)
                {
                    return;
                }
            }
            
        }
        private void ConnectCallback(IAsyncResult AR)
        {
            try
            {
                clientSocket.EndConnect(AR);
            }
            catch (SocketException ex)
            {
                
            }
            catch (ObjectDisposedException ex)
            {
               
            }
        }

        private void ReceiveCallback(IAsyncResult AR)
        {
            try
            {
                int received = clientSocket.EndReceive(AR);

                if (received == 0)
                {
                    return;
                }


                
                object obj = Serializer.Deserialize(am);
                if (obj is PacoteLogin)
                {
                   ProcessLogin(obj as PacoteLogin);
                }

 
            }
            // Avoid Pokemon exception handling in cases like these.
            catch (SocketException ex)
            {

            }
            catch (ObjectDisposedException ex)
            {
            }
        }

        private PacoteLogin ProcessLogin(PacoteLogin pacoteLogin)
        {
            string response = pacoteLogin.GetResponse();
            PacoteLogin ret = null;
            if (response.Equals("CSucesso") || response.Equals("CProprietario"))
                ret = new PacoteLogin(pacoteLogin.GetUtilizador(), "Login Sucesso!");
            
            return ret;
        }

        private void SendCallback(IAsyncResult AR)
        {
            try
            {
                clientSocket.EndSend(AR);
                clientSocket.BeginReceive(am.Data, 0, am.Data.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), null);
                
            }
            catch (SocketException ex)
            {
                
            }
            catch (ObjectDisposedException ex)
            {
               
            }
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
                    clientSocket.BeginSend(sending.Data, 0, sending.Data.Length, SocketFlags.None, new AsyncCallback(SendCallback), ret);
                 
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