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

namespace Nhamalicious
{

    [Activity(Label = "Nhamalicious", Icon = "@drawable/icon")]
    public class PagInicialActivity : Activity
    {
        private List<string> mItems;
        private ListView mListView;

        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.PagPesquisa);
            mListView = FindViewById<ListView>(Resource.Id.myListView);
            mItems = new List<string>();
            mItems.Add("Bob");
            mItems.Add("Maria");

            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, mItems);

            mListView.Adapter = adapter;

        }
    }
}