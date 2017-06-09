using Android.App;
using Android.OS;
using Android.Widget;
using System;
using System.Collections.Generic;

using System.IO;
using System.Net;
using System.Net.Sockets;
using Nhamalicious.Resources.Code;

namespace Nhamalicious
{
    [Activity(Label = "Nhamalicious", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private ImageButton mBtnPesquisa;
        private Button mBtnCozinhaIndiana;
        private Button mBtnCozinhaVegan;
        private Button mBtnCozinhaJaponesa;
        private Button mBtnCozinhaChinesa;
        private Button mBtnRegLogin;

        PedidoCli c = new PedidoCli();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.PagInicial);
            c.ConnectToServer();

            
            mBtnPesquisa = FindViewById<ImageButton>(Resource.Id.btnPesquisa);
            mBtnCozinhaIndiana = FindViewById<Button>(Resource.Id.btnCozinhaIndiana);
            mBtnCozinhaVegan = FindViewById<Button>(Resource.Id.btnCozinhaVegan);
            mBtnCozinhaJaponesa = FindViewById<Button>(Resource.Id.btnCozinhaJaponesa);
            mBtnCozinhaChinesa = FindViewById<Button>(Resource.Id.btnCozinhaChinesa);
            mBtnRegLogin = FindViewById<Button>(Resource.Id.btnParaRegOuLog);

            mBtnPesquisa.Click += delegate
            {
                StartActivity(typeof(RegLoginActivity));
            };
            mBtnCozinhaIndiana.Click += delegate
            {
                StartActivity(typeof(RegLoginActivity));
            };
            mBtnCozinhaVegan.Click += delegate
            {
                StartActivity(typeof(RegLoginActivity));
            };
            mBtnCozinhaJaponesa.Click += delegate
            {
                StartActivity(typeof(RegLoginActivity));
            };
            mBtnCozinhaChinesa.Click += delegate
            {
                StartActivity(typeof(RegLoginActivity));
            };
            mBtnRegLogin.Click += delegate
            {
                StartActivity(typeof(RegLoginActivity));
            };
        }
    }
}

