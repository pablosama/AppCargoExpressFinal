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
    [Activity(Label = "AwardedCargoesActivity", Theme = "@android:style/Theme.NoTitleBar")]
    public class AwardedCargoesActivity : Activity
    {
        private List<string> mItems;
        private ListView mListView;
        private Button btnVolver;
        private int typeOfUser;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AwardedCargoes);
            mListView = FindViewById<ListView>(Resource.Id.lstAc);
            typeOfUser = int.Parse(AuthService.UserType);

            LayoutInflater inflater = (LayoutInflater)this.GetSystemService(Context.LayoutInflaterService);

            View headerView = inflater.Inflate(Resource.Layout.CargoesHeader, null);
            TextView lblTextHeader = (TextView)headerView.FindViewById<TextView>(Resource.Id.lblChTitleList);
            lblTextHeader.SetText(Resource.String.AwardedCargoesTitle);

            View footerView = inflater.Inflate(Resource.Layout.CargoesFooter, null);

            mItems = new List<string> { "viaje N°1", "viaje N°2", "viaje N°3", "viaje N°4", "viaje N°5", "viaje N°6" };
            ArrayAdapter<string> adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, mItems);

            mListView.AddHeaderView(headerView);
            mListView.AddFooterView(footerView);
            mListView.Adapter = adapter;

            btnVolver = FindViewById<Button>(Resource.Id.btnCfReturn);
            btnVolver.Click += delegate
            {
                Intent nextScreen = new Intent(this, typeof(MainHistoricalActivity));               
                StartActivity(nextScreen);
            };
        }
    }
}