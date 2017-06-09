using System;
using System.ComponentModel;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Text;
using ClassesPartilhadas;
using API_Acesso_BD;
using NhamiBackEnd1.Code.AcessoBD;

namespace Server
{
    public partial class TurnOn : Form
    {
        Server s = new Server();
        public TurnOn()
        {

            InitializeComponent();
            l_displayPort.Text = Server.port.ToString();
            l_displayIP.Text = getMyExternalIP();

            tb_activity.AppendText(Testar.testarBD());
        }

        private string getMyExternalIP()
        {
            return new WebClient().DownloadString("http://icanhazip.com");
        }

        private void b_start_Click(object sender, EventArgs e) //start server
        {

            s.Run();
            tb_activity.AppendText("\nStarting server ...");
        }

        private void b_Stop_Click(object sender, EventArgs e)
        {
            tb_activity.AppendText("\nClosing connections");
            s.Stop();
            Environment.Exit(Environment.ExitCode);
        }

        private void tb_activity_TextChanged(object sender, EventArgs e)
        {

        }

        public static void SetActivityText(string msg)
        {
            tb_activity.AppendText("\n" + msg);
        }
    }
}


