using Android.App;
using Android.OS;
using Android.Widget;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;


namespace Nhamalicious
{
    [Activity(Label = "Nhamilicious", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button mBtnLogin;
        private TcpClient tpc = new TcpClient();
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            tpc.Connect(IPAddress.Parse("192.168.1.92"), 80);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            mBtnLogin = FindViewById<Button>(Resource.Id.botaoLogin);

            mBtnLogin.Click += MBtnLogin_Click;

        }

        private void MBtnLogin_Click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            Dialog_Login loginD = new Dialog_Login();
            loginD.Show(transaction, "dialog fragment");
            throw new NotImplementedException();
        }
    }
}

