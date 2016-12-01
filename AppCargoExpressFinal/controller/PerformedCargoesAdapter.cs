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
    public class PerformedCargoesAdapter : BaseAdapter<models.PerformedCagoes>
    {
        private List<models.PerformedCagoes> mItems;
        private Context mContext;
       
        public PerformedCargoesAdapter(Context context, List<models.PerformedCagoes> items)
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

        public override PerformedCagoes this[int position]
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

            TextView numeroOperacion = row.FindViewById<TextView>(Resource.Id.lblPcNumOperation);
            numeroOperacion.Text = mItems[position].getNumeroOperacion().ToString();

            TextView origenDestino = row.FindViewById<TextView>(Resource.Id.lblPcOriginDestiny);
            origenDestino.Text = mItems[position].getOrigenDestino();

            TextView fecha = row.FindViewById<TextView>(Resource.Id.lblPcDateList);
            fecha.Text = mItems[position].getFecha().ToString();

            return row;
        }
    }
}