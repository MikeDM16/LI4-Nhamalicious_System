using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ClassesPartilhadas; 

namespace Nhamalicious
{

    [Activity(Label = "Nhamalicious", Icon = "@drawable/icon")]
    public class PagPesquisaActivity : Activity
    {
        private List<Resultado> mItems;
        private ListView mListView;

        //public void DevolveResultados(List<Restaurante> lista)
        //{
        //    StartActivity(typeof(PagPesquisaActivity));
        //    base.OnCreate(savedInstanceState);

        //    SetContentView(Resource.Layout.PagPesquisa);
        //    mListView = FindViewById<ListView>(Resource.Id.myListView);
        //    mItems = new List<Resultado>();MyListViewAdapter adapter = new MyListViewAdapter(this, mItems);

        //    List<Restaurante> rests = null;
        //    foreach (Restaurante r in rests)
        //    {
        //        List<Prato> pratos = r.GetMenu();
        //        foreach (Prato p in pratos)
        //        {
        //            string nomeP, nomeR, desc, cozinha = "n/a";
        //            int tipoC;
        //            string preco;

        //            nomeP = p.GetDesignacao();
        //            nomeR = r.GetDesignacao();
        //            desc = p.GetDescricao(); preco = "" + p.GetPreco() + " €";
        //            tipoC = r.GetIdTipoCozinha();

        //            if (tipoC == 1) { cozinha = "Chinesa"; }
        //            if (tipoC == 2) { cozinha = "Japonesa"; }
        //            if (tipoC == 3) { cozinha = "Indiana"; }
        //            if (tipoC == 4) { cozinha = "Vegetariana"; }
        //            Resultado res = new Resultado() { NomePrato = nomeP, NomeRestaurante = nomeR, Descricao = desc, Preco = preco, TipoCozinha = cozinha };
        //            mItems.Add(res);

        //        }

        //    }

        //    mListView.Adapter = adapter;

        //}

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.PagPesquisa);
            mListView = FindViewById<ListView>(Resource.Id.myListView);
            mItems = new List<Resultado>();

            mItems.Add(new Resultado { NomePrato = "Arroz de Frango", NomeRestaurante = "Wok to Wok", Preco = "10€", TipoCozinha = "Cozinha Indiana" });
            mItems.Add(new Resultado { NomePrato = "Sushi", NomeRestaurante = "Napas", Preco = "22,5€", TipoCozinha = "Cozinha Japonesa"});
            mItems.Add(new Resultado { NomePrato = "Paneer Pakora", NomeRestaurante = "Restaurante Tandoori", Preco = "15€", TipoCozinha = "Cozinha Indiana" });
            mItems.Add(new Resultado { NomePrato = "Frango", NomeRestaurante = "Wok to Wok", Preco = "10€", TipoCozinha = "Cozinha Chinesa" });
            mItems.Add(new Resultado { NomePrato = "Sushi", NomeRestaurante = "Napas", Preco = "22,5€",TipoCozinha = "Cozinha Japonesa" });
            mItems.Add(new Resultado { NomePrato = "Frango", NomeRestaurante = "Ola", Preco = "12€", TipoCozinha = "Cozinha Chinesa" });
            MyListViewAdapter adapter = new MyListViewAdapter(this, mItems);


            //List<Restaurante> rests = null;
            //foreach (Restaurante r in rests) {
            //    List<Prato> pratos = r.GetMenu();
            //    foreach (Prato p in pratos)
            //    {
            //        string nomeP, nomeR, desc, cozinha = "n/a";
            //        int tipoC;
            //        string preco;

            //        nomeP = p.GetDesignacao();
            //        nomeR = r.GetDesignacao();
            //        desc  = p.GetDescricao(); preco = "" +  p.GetPreco() + " €";
            //        tipoC = r.GetIdTipoCozinha();
                    
            //        if(tipoC == 1) { cozinha = "Chinesa";  }
            //        if (tipoC == 2) { cozinha = "Japonesa"; }
            //        if (tipoC == 3) { cozinha = "Indiana"; }
            //        if (tipoC == 4) { cozinha = "Vegetariana"; }
            //        Resultado res = new Resultado() { NomePrato = nomeP, NomeRestaurante = nomeR, Descricao = desc, Preco = preco, TipoCozinha = cozinha};
            //        mItems.Add(res);

            //    }

            //}

            mListView.Adapter = adapter;

        }
    }
}