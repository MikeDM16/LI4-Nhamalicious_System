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
    class MyListViewAdapter : BaseAdapter<Resultado>
    {
        private List<Resultado> mItems;
        private Context mContext;

        public MyListViewAdapter(Context context, List<Resultado> items)
        {
            mContext = context;
            mItems = items;
        }

        public override int Count
        {
            get { return mItems.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Resultado this[int position]
        {
            get { return mItems[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.listview_row, null, false);
            }

            TextView nomePrato = row.FindViewById<TextView>(Resource.Id.NomePrato);
            nomePrato.Text = mItems[position].NomePrato;
            TextView nomeRestaurante = row.FindViewById<TextView>(Resource.Id.NomeRestaurante);
            nomeRestaurante.Text = mItems[position].NomeRestaurante;
            TextView tipoCozinha = row.FindViewById<TextView>(Resource.Id.TipoCozinha);
            tipoCozinha.Text = mItems[position].TipoCozinha;
            TextView preco = row.FindViewById<TextView>(Resource.Id.Preco);
            preco.Text = mItems[position].Preco;

            return row;
        }
    }
}