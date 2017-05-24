using System;
using System.ComponentModel;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;
using NhamiBackEnd1.Code;
using NhamiBackEnd1.Code.AcessoBD;

namespace NhamiBackEnd1
{
    public partial class Form1 : Form
    {
        Server s;
        public Form1()
        {
            InitializeComponent();
            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());

            foreach(IPAddress ipa in ips)
            {
                if (ipa.AddressFamily == AddressFamily.InterNetwork)

                l_displayIP.Text = ipa.ToString();
            }
            tb_activity.Text = Testar.testarBD();
        }


        private void b_start_Click(object sender, EventArgs e) //start server
        {

            int port = int.Parse(tf_portChoice.Text);
            s.Run(l_displayIP.Text, port);
            Console.WriteLine("Starting server ...");
            
        }

        private void b_Stop_Click(object sender, EventArgs e)
        {

        }

        private void tb_activity_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
