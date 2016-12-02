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
    [Activity(Label = "AwardedCargoesActivity", Theme = "@android:style/Theme.NoTitleBar")]
    public class AwardedCargoesActivity : Activity
    {

        private List<PerformedCargoes> mItems = new List<PerformedCargoes>()
        {
            new PerformedCargoes ("Roberto Hidalgo","03/11/2016","Pto. Montt - Chiloé","Artículo Hogar","$150.000"),
            new PerformedCargoes ("Cristian Aparicio","04/11/2016","Pta. Arenas - Coyhaique","Mudanza","$200.000")
        };
        private ListView mListView;
        private Button btnVolver;
        private int typeOfUser;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AwardedCargoesMain);

            typeOfUser = int.Parse(AuthService.UserType);

            mListView = FindViewById<ListView>(Resource.Id.lstAcAwarded);

            LayoutInflater inflater = (LayoutInflater)this.GetSystemService(Context.LayoutInflaterService);
            View headerView = inflater.Inflate(Resource.Layout.CargoesHeader, null);
            TextView lblTextHeader = (TextView)headerView.FindViewById<TextView>(Resource.Id.lblChTitleList);
            lblTextHeader.SetText(Resource.String.AwardedCargoesTitle);

            View footerView = inflater.Inflate(Resource.Layout.CargoesFooter, null);
            PerformedCargoesAdapter adapter = new PerformedCargoesAdapter(this, mItems);
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