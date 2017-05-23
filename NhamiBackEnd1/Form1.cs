using System;
using System.ComponentModel;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;


namespace NhamiBackEnd1
{
    public partial class Form1 : Form
    {
        private TcpClient tpc;
        
        private StreamReader st;
        private StreamWriter sw;
        private string send;
        private string receive;

        public Form1()
        {
            InitializeComponent();
            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());

            foreach(IPAddress ipa in ips)
            {
                if (ipa.AddressFamily == AddressFamily.InterNetwork)

                l_displayIP.Text = ipa.ToString();
            }

        }


        private void b_start_Click(object sender, EventArgs e) //start server
        {
            TcpListener tpl = new TcpListener(IPAddress.Any, int.Parse(tf_portChoice.Text));
            tpl.Start();
            while(true)
            {
                tpc = tpl.AcceptTcpClient();
                if (tpc.Connected)
                {
                    tb_activity.Text = "New Connection!";
                    st = new StreamReader(tpc.GetStream());
                    sw = new StreamWriter(tpc.GetStream());
                    sw.AutoFlush = true;
                    backgroundWorker1.RunWorkerAsync();                     //works background
                    backgroundWorker2.WorkerSupportsCancellation = true;    //can cancel writing
                }
            }

            
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e) //receive from socket
        {
            while (tpc.Connected){
                try
                {
                    tb_activity.Invoke(new MethodInvoker(delegate () {
                        tb_activity.AppendText("Nova conexão!\n");}));      
                }
                catch(Exception x)
                {
                    MessageBox.Show(x.Message.ToString());
                }
            }
        }

        private void BackgroundWorker2_DoWork(object sender, DoWorkEventArgs e) //write on socket
        {
            while (tpc.Connected)
            {
                try
                {
                    tb_activity.Invoke(new MethodInvoker(delegate () {
                        tb_activity.AppendText("Nova conexão!\n");
                    }));
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message.ToString());
                }
            }
            backgroundWorker2.CancelAsync();
        }

    }
}
