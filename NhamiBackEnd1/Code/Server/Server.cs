using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;

namespace NhamiBackEnd1.Code
{
    class Server
    {
        static Socket serverSocket;
        static List<ClientData> clients_connected;
        Thread listeningThread;
        bool on_off = true;
        public static readonly int port = 3333;


        public static void ShowErrorDialog(string message)
        {
            MessageBox.Show(message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        /// <summary>
        /// Construct server socket and bind socket to all local network interfaces, then listen for connections
        /// with a backlog of 10. Which means there can only be 10 pending connections lined up in the TCP stack
        /// at a time. This does not mean the server can handle only 10 connections. The we begin accepting connections.
        /// Meaning if there are connections queued, then we should process them.
        /// </summary>
        public void Run()
        {
            try
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(new IPEndPoint(IPAddress.Any, port));
                serverSocket.Listen(10);
                serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
            }
            catch (SocketException ex)
            {
                ShowErrorDialog(ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                ShowErrorDialog(ex.Message);
            }

        }
        

        public void Stop()
        {
            foreach(ClientData cd in clients_connected)
            {
                cd.StopConnection();
            }
        }

        private void AcceptCallback(IAsyncResult AR)
        {
            try
            {
                ClientData client = new ClientData(serverSocket.EndAccept(AR));
                clients_connected.Add(client);

                // Continue listening for clients.
                serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
            }
            catch (SocketException ex)
            {
                ShowErrorDialog(ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                ShowErrorDialog(ex.Message);
            }
        }


        public static void Data_IN(object cSocket) //recebe os dados
        {
            Socket s = (Socket)cSocket;
            try
            {
                byte[] bufferA = new byte[s.SendBufferSize];
                s.BeginReceive(bufferA, 0, bufferA.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), null);
            }
            catch (SocketException ex)
            {
                Server.ShowErrorDialog(ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                Server.ShowErrorDialog(ex.Message);
            }
        }

        private static void ReceiveCallback(IAsyncResult AR)
        {
            try
            {

                // Socket exception will raise here when client closes, as this sample does not
                // demonstrate graceful disconnects for the sake of simplicity.
                Socket s = (Socket)AR.AsyncState;
                int received = s.EndReceive(AR);

                if (received == 0)
                {
                    return;
                }

                // The received data is deserialized in the PersonPackage ctor.
                Pacote p = new Pacote();

                // Start receiving data again.
                //clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveCallback, null);
            }
            // Avoid Pokemon exception handling in cases like these.
            catch (SocketException ex)
            {
                Server.ShowErrorDialog(ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                Server.ShowErrorDialog(ex.Message);
            }
        }


    }

  

    class ClientData
    {
        Socket clientSocket;
        Thread clientThread;
        //Utilizador u ;-> aqui vamos guardar se está login, ou convidado 
        //Classe abstracta Utilizador que possamos depois dividir por Cliente, Convidado e Dono

        public ClientData()
        {
            //Colocar utilizador como convidado, pq não foi feito o login
        }

        public ClientData(Socket s)
        {
            //Colocar utilizador como convidado, pq não foi feito o login
            clientSocket = s;
            clientThread = new Thread(Server.Data_IN);
            clientThread.Start(this);
        }
        //public void setUtilizador(Utilizador u)
        //{
        //    if (u is Cliente) { /*set Utilizador to the Client, deve ser usado depois do login*/}
        //    if (u is Dono) { }
        //    if (u is Convidado) { }
        //}

        public void StopConnection()
        {
            clientSocket.Shutdown(SocketShutdown.Both);
        }
        
    }
}
