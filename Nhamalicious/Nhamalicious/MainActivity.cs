using Android.App;
using Android.OS;
using Android.Widget;
using System;
using System.Collections.Generic;

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
        private Button mBtnRegisto;
        //PedidoCli c = new PedidoCli();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            

            mBtnLogin = FindViewById<Button>(Resource.Id.botaoLogin);
            mBtnRegisto = FindViewById<Button>(Resource.Id.botaoSignUp);

            mBtnLogin.Click += (object sender, EventArgs args) =>
            {
                //Pulls up the Dialog Window
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                DialogLoginClass d1 = new DialogLoginClass();
                d1.Show(transaction, "dialog fragment");
                d1.LoginEfetuado += D1_LoginEfetuado;
            };


            mBtnRegisto.Click += (object sender, EventArgs args) =>
            {
                //Carrega a página de popup do registo
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                DialogRegistoClass d2 = new DialogRegistoClass();
                d2.Show(transaction, "dialog fragment");
                d2.RegistoEfetuado += D2_RegistoEfetuado;
            };
        }
        private void D2_RegistoEfetuado(object sender, OnRegistoEventArgs e)
        {
            TcpClient tcp = new TcpClient();
            tcp.Connect(IPAddress.Parse("192.168.1.92"), 80);
            // e.Username já é o que o cliente escreve, falta fazer a ligação com o servidor e com os métodos correspondentes
            // e.Password igual ao username
            //para os restantes também se faz igual (email, nome...)
        }

        private void D1_LoginEfetuado(object sender, OnLoginEventArgs e)
        {
            //c.LoginAtempt(e.Username, e.Password);
            // e.Username já é o que o cliente escreve, falta fazer a ligação com o servidor e com os métodos correspondentes
            // e.Password igual ao username
        }

        
    }
}

