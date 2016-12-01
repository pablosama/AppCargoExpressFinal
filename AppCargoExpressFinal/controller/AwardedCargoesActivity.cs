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

namespace AppCargoExpressFinal.controller
{
    [Activity(Label = "AwardedCargoesActivity")]
    public class AwardedCargoesActivity : Activity
    {
        private List<string> mItems;
        private ListView mListView;
        private TextView listTitle;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AwardedCargoes);
            mListView = FindViewById<ListView>(Resource.Id.lstAc);
            //listTitle = (View)getLayoutInflater().inflate(Resource.Id.lblAcTitle, null);// FindViewById<TextView>(Resource.Id.lblAcTitle);

            //ViewGroup header = (ViewGroup)inflater.inflate(R.layout.header, myListView, false);

            mItems = new List<string> { "viaje N°1", "viaje N°2", "viaje N°3", "viaje N°4", "viaje N°5", "viaje N°6" };
            ArrayAdapter<string> adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, mItems);
            //mListView.AddHeaderView(listTitle);       
            mListView.Adapter = adapter;
        }
    }
}