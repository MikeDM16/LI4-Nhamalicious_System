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
using NhamiBackEnd1.Code;
using NhamiBackEnd1.Code.AcessoBD;
using NhamiBackEnd1.Code.SharedClasses;

namespace NhamiBackEnd1
{
    public class Server
    {
        static Socket serverSocket;
        static List<ClientData> clients_connected = new List<ClientData>();
        public static readonly int port = 3333;
        static DAOGestaoUtilizadores dao_gestUtil = new DAOGestaoUtilizadores();
        

        public Server() { }
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
                serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), serverSocket);
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
            //foreach(ClientData cd in clients_connected)
            //{
            //    cd.StopConnection();
            //}
            serverSocket.Close();
            serverSocket.Dispose();
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
            ClientData cd = (ClientData)cSocket;
            try
            {
                cd.Setbuffer(cd.GetSocket().SendBufferSize);
                cd.GetSocket().BeginReceive(cd.GetBuffer(), 0, cd.GetBuffer().Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), cd);
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
                ClientData cd = (ClientData)AR.AsyncState;
                Socket client_socket = cd.GetSocket();
                int received = client_socket.EndReceive(AR);

                if (received == 0)
                {
                    return;
                }

                // The received data is deserialized in the PersonPackage ctor.
                byte[] buf = new byte[cd.GetBuffer().Length];
                Array.Copy(cd.GetBuffer(), buf, cd.GetBuffer().Length);
                int p = BitConverter.ToInt32(buf, 0);
                PacoteType pt = (PacoteType)p;
                switch (pt)
                {
                    case PacoteType.Login:
                        {
                            TurnOn.SetActivityText("Login Attempt...");
                            PacoteLogin pl = new PacoteLogin();
                            pl.Deserialize(buf, 4);
                            int answer = dao_gestUtil.LoginUtilizador(pl.GetUsername(), pl.GetPassword());
                            //Utilizador u = dao_gestUtil.LoginUtilizador(pl.GetUsername(), pl.GetPassword());
                            /*
                             * if (u == null){
                             *      PacoteLogin pl_send = new PacoteLogin(null, "Login Failed!");
                                    client_socket.BeginSend(pl_send.ToByteArray(), 0, pl_send.ToByteArray().Length, SocketFlags.None, new AsyncCallback(SendCallback), cd);
                             * }
                             * else{
                             *      if (u is Cliente){
                             *          Cliente c = (Cliente) u; 
                             *          //PacoteLogin pl_send = new PacoteLogin(c, "CSucesso");
                             *          cd.SetUtilizador(c);
                                        //client_socket.BeginSend(pl_send.ToByteArray(), 0, pl_send.ToByteArray().Length, SocketFlags.None, new AsyncCallback(SendCallback), cd);
                             *      }
                             *      else{
                             *          Proprietario p = (Proprietario)u;
                             *          cd.SetUtilizador(c);
                             *          //PacoteLogin pl_send = new PacoteLogin(p, "PSucesso");
                                        //client_socket.BeginSend(pl_send.ToByteArray(), 0, pl_send.ToByteArray().Length, SocketFlags.None, new AsyncCallback(SendCallback), cd);
                             *     
                             *      }  
                             * }
                             * */
                            switch (answer)
                            {
                                case 0:
                                    {
                                        PacoteLogin pl_send = new PacoteLogin(null, "Login Failed!");
                                        client_socket.BeginSend(pl_send.ToByteArray(), 0, pl_send.ToByteArray().Length, SocketFlags.None, new AsyncCallback(SendCallback), cd);
                                    }
                                    break;
                                case 1:
                                    {
                                        //Cliente c =
                                        //PacoteLogin pl_send = new PacoteLogin(c, "Cliente Sucesso");
                                        //client_socket.BeginSend(pl_send.ToByteArray(), 0, pl_send.ToByteArray().Length, SocketFlags.None, new AsyncCallback(SendCallback), cd);
                                    }
                                    break;
                            }
                            //Faz as operações para verificar o login
                        }
                        break;
                }
                
                cd.GetSocket().BeginReceive(cd.GetBuffer(), 0, cd.GetBuffer().Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), cd);
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

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                ClientData cd = (ClientData)ar.AsyncState;
                cd.GetSocket().EndSend(ar);
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
    }

    class ClientData
    {
        Socket clientSocket;
        byte[] buffeR;
        Utilizador u ; //-> aqui vamos guardar se está login, ou convidado 
        //Classe abstracta Utilizador que possamos depois dividir por Cliente, Convidado e Dono

        public ClientData()
        {
            //Colocar utilizador como convidado, pq não foi feito o login
            
        }

        public void Setbuffer(int a)
        {
            this.buffeR = new byte[a];
        }

        public Socket GetSocket()
        {
            return clientSocket;
        }

        public byte[] GetBuffer()
        {
            return buffeR;
        }
        public ClientData(Socket s)
        {
            //Colocar utilizador como convidado, pq não foi feito o login
            clientSocket = s;
            Server.Data_IN(this);
        }

        //public void setUtilizador(Utilizador u)
        //{
        //    if (u is Cliente)
        //    { /*set Utilizador to the Client, deve ser usado depois do login*/
        //    }
        //    if (u is Dono) { }
        //    if (u is Convidado) { }
        //}

        public void StopConnection()
        {
            clientSocket.Shutdown(SocketShutdown.Both);
        }
        
    }
}
