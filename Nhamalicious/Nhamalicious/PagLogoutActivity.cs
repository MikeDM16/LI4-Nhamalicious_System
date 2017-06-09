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
    [Activity(Label = "Nhamalicious", Icon = "@drawable/icon")]
    public class PagLogoutActivity : Activity
    {
        private EditText mPratoPesquisa;
        private ImageButton mBtnPesquisa;
        private Button mBtnCozinhaIndiana;
        private Button mBtnCozinhaVegan;
        private Button mBtnCozinhaJaponesa;
        private Button mBtnCozinhaChinesa;
        private Button mBtnLogout;

        //PedidoCli c = new PedidoCli();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.PagInicial);

            mPratoPesquisa = FindViewById<EditText>(Resource.Id.txtInserePrato);
            mBtnPesquisa = FindViewById<ImageButton>(Resource.Id.btnPesquisa);
            mBtnCozinhaIndiana = FindViewById<Button>(Resource.Id.btnCozinhaIndiana);
            mBtnCozinhaVegan = FindViewById<Button>(Resource.Id.btnCozinhaVegan);
            mBtnCozinhaJaponesa = FindViewById<Button>(Resource.Id.btnCozinhaJaponesa);
            mBtnCozinhaChinesa = FindViewById<Button>(Resource.Id.btnCozinhaChinesa);
            mBtnLogout = FindViewById<Button>(Resource.Id.btnLogout);


            mBtnPesquisa.Click += delegate
            {
                if (mPratoPesquisa.Text != null)
                {
                    //List<Restaurante> rest = null;
                    //chamar método FACADE rest = método
                    //PagPesquisaActivity pag = new PagPesquisaActivity();
                    StartActivity(typeof(PagPesquisaActivity));
                }

            };
            mBtnCozinhaIndiana.Click += delegate
            {
                StartActivity(typeof(PagPesquisaActivity));
            };
            mBtnCozinhaVegan.Click += delegate
            {
                StartActivity(typeof(PagPesquisaActivity));
            };
            mBtnCozinhaJaponesa.Click += delegate
            {
                StartActivity(typeof(PagPesquisaActivity));
            };
            mBtnCozinhaChinesa.Click += delegate
            {
                StartActivity(typeof(PagPesquisaActivity));
            };
            mBtnLogout.Click += delegate
            {
                StartActivity(typeof(MainActivity));
            };
        }
    }
}

