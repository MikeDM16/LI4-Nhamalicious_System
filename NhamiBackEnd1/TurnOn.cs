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
    public partial class TurnOn : Form
    {
        Server s = new Server();
        public TurnOn()
        {
            InitializeComponent();
        }


        private void b_start_Click(object sender, EventArgs e) //start server
        {

            int port = int.Parse(tf_portChoice.Text);
            s.Run(port);
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
