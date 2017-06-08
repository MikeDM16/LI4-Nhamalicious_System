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
using API_Acesso_BD;

namespace Nhamalicious
{
    [Activity(Label = "Nhamalicious", Icon = "@drawable/icon")]
    public class RegLoginActivity : Activity
        {
            private Button mBtnLogin;
            private Button mBtnRegisto;
            //private Facade facade = new Facade();

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
                
                
                int u = Facade.RegistaUtilizador(e.Utilizador);
                if (u == -2)
                {
                    //-2 se já existir
                    //0 sucesso
                    //1 nop
                    AlertDialog.Builder ad = new AlertDialog.Builder(this);
                    ad.SetTitle("Ooops!");
                    ad.SetMessage("O utilizador já existe!");
                    ad.SetNeutralButton("Ok", delegate
                    {
                        ad.Dispose();
                    });
                    ad.Show();
                }
        }
        
            private void D1_LoginEfetuado(object sender, OnLoginEventArgs e)
            {                               
                Utilizador u = Facade.ConnectLogin(e.Username, e.Password);
                
                if (u is Proprietario)
                {
                    AlertDialog.Builder ad = new AlertDialog.Builder(this);
                    ad.SetTitle("Proprietario");
                    ad.SetMessage("Bem vindo Proprietario ! " + u.GetNome());
                    ad.SetNeutralButton("Ok", delegate
                    {
                        ad.Dispose();
                    });
                    ad.Show();
                }
                else
                {
                    if (u is Cliente)
                    {
                        AlertDialog.Builder ad = new AlertDialog.Builder(this);
                        ad.SetTitle("Cliente");
                        ad.SetMessage("Bem vindo cliente !");
                        ad.SetNeutralButton("Ok", delegate
                        {
                            ad.Dispose();
                        });
                        ad.Show();
                    }
                    else
                    {
                        AlertDialog.Builder ad = new AlertDialog.Builder(this);
                        ad.SetTitle("Erro mudou ??");
                        ad.SetMessage("A tua password ou username devem estar erradas !");
                        ad.SetNeutralButton("Ok", delegate
                        {
                            ad.Dispose();
                        });
                        ad.Show();
                    }
                }
            }
    }
}