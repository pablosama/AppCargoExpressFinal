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
using AppCargoExpressFinal.models;

namespace AppCargoExpressFinal.controller
{
    public class PerformedCargoesAdapter : BaseAdapter<models.PerformedCargoes>
    {
        private List<models.PerformedCargoes> mItems;
        private Context mContext;
       
        public PerformedCargoesAdapter(Context context, List<models.PerformedCargoes> items)
        {
            mItems = items;
            mContext = context;
        }

        public override int Count
        {
            get
            {
                return mItems.Count;
            }
        }

        public override PerformedCargoes this[int position]
        {
            get
            {
                return mItems[position];
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.PerformedCargoes, null, false);
            }

            TextView usuario = row.FindViewById<TextView>(Resource.Id.txtPcUser);
            usuario.Text = mItems[position].getUsuario().ToString();

            TextView origenDestino = row.FindViewById<TextView>(Resource.Id.txtPcOriginDestiny);
            origenDestino.Text = mItems[position].getOrigenDestino();

            TextView fecha = row.FindViewById<TextView>(Resource.Id.txtPcDate);
            fecha.Text = mItems[position].getFecha().ToString();

            TextView tipoCarga = row.FindViewById<TextView>(Resource.Id.txtPcCargoType);
            tipoCarga.Text = mItems[position].getTipoCarga().ToString();

            TextView monto = row.FindViewById<TextView>(Resource.Id.txtPcValue);
            monto.Text = mItems[position].getMonto().ToString();


            return row;
        }

       
    }
}