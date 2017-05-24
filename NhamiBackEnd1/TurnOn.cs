using System;
using System.ComponentModel;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;
using NhamiBackEnd1.Code;

namespace NhamiBackEnd1
{
    public partial class TurnOn : Form
    {
        Server s = new Server();
        public TurnOn()
        {
            
            InitializeComponent();
            l_displayPort.Text = Server.port.ToString();
            l_displayIP.Text = getMyExternalIP();
        }

        private string getMyExternalIP()
        {
            return new WebClient().DownloadString("http://icanhazip.com");       
        }

        private void b_start_Click(object sender, EventArgs e) //start server
        {

            s.Run();
            tb_activity.Text += "Starting server ...\n";
            tb_activity.Text += "Beijo\n";
        }

        private void b_Stop_Click(object sender, EventArgs e)
        {
            tb_activity.Text += "Closing connections";
            s.Stop();
            Environment.Exit(Environment.ExitCode);
        }

        private void tb_activity_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
