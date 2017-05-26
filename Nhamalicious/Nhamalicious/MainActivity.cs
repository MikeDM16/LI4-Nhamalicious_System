using Android.App;
using Android.OS;
using Android.Widget;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using Nhamalicious.Resources.Code;
using ClassesPartilhadas;

namespace Nhamalicious
{
    [Activity(Label = "Nhamalicious", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button mBtnLogin;
        PedidoCli c = new PedidoCli();
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            c.LoginAtempt("John", "123");

            mBtnLogin = FindViewById<Button>(Resource.Id.botaoLogin);

            mBtnLogin.Click += (object sender, EventArgs args) => 
            {
                //Pulls up the Dialog Window
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                DialogLoginClass d1 = new DialogLoginClass();
                d1.Show(transaction, "dialog fragment");
                d1.LoginEfetuado += D1_LoginEfetuado;
            };

        }

        private void D1_LoginEfetuado(object sender, OnLoginEventArgs e)
        {
            TcpClient tcp = new TcpClient();
            tcp.Connect(IPAddress.Parse("192.168.1.92"), 80);
            // e.Username já é o que o cliente escreve, falta fazer a ligação com o servidor e com os métodos correspondentes
            // e.Password igual ao username
        }
    }
}

