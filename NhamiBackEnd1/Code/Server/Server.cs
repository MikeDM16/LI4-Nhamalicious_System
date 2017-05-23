using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Net.Sockets;

namespace NhamiBackEnd1.Code
{
    class Server
    {
        static Socket accepting_connections;
        static List<ClientData> clients_connected;
        bool on_off = true;

        public void Run(String ip, int port)
        {
            accepting_connections = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clients_connected = new List<ClientData>();

            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(ip), port);

            accepting_connections.Bind(iep);

            while (on_off)
            {
                Thread listeningThread = new Thread(ListenThread);
                listeningThread.Start();

            }

        }
        public void Stop()
        {
            on_off = false;
        }
        static void ListenThread()
        {
            while (true)
            {
                accepting_connections.Listen(50);
                clients_connected.Add(new ClientData(accepting_connections.Accept()));
            }
        }

        public static void Data_IN(object cSocket) //recebe os dados
        {
            Socket s = (Socket)cSocket;

            byte[] buffer;
            int nBytes;

            while (true)
            {
                buffer = new byte[s.SendBufferSize];

                nBytes = s.Receive(buffer);

                if ( nBytes > 0)
                {

                }


            }
        }
        
        public static void DataManager(Pacote p)
        {

        }

        public string getIPV4()
        {
            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());
            foreach(IPAddress i in ips)
            {
                if (i.AddressFamily == AddressFamily.InterNetwork)
                {
                    return i.ToString();
                }
            }

            return "127.0.0.1";
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
            clientThread.Start(clientSocket);
        }
        //public void setUtilizador(Utilizador u)
        //{
        //    if (u is Cliente) { /*set Utilizador to the Client, deve ser usado depois do login*/}
        //    if (u is Dono) { }
        //    if (u is Convidado) { }
        //}

    }
}
