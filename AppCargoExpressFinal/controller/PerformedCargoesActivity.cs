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
    [Activity(Label = "PerformedCargoesActivity")]
    public class PerformedCargoesActivity : Activity
    {

        private List<PerformedCagoes> mItems = new List<PerformedCagoes>()
        {
            new PerformedCagoes (1001,"05/11/2016","Pto. Montt - Santiago"),
            new PerformedCagoes (1002,"06/11/2016","Santiago - Arica"),
            new PerformedCagoes (1003,"07/11/2016","Coquimbo - Concepción"),
            new PerformedCagoes (1004,"08/11/2016","Concepción - Temuco"),
            new PerformedCagoes (1005,"15/11/2016","Temuco - Osorno"),
            new PerformedCagoes (1006,"16/11/2016","Osorno - Lanco"),
            new PerformedCagoes (1007,"17/11/2016","Lanco - Valdivia"),
            new PerformedCagoes (1008,"18/11/2016","Valdivia - Pto. Montt"),
            new PerformedCagoes (1009,"19/11/2016","Pto. Montt - Chiloé"),
            new PerformedCagoes (10010,"20/11/2016","Pta. Arenas - Cohyaique")
        };
        private ListView mListView;
        private Button btnVolver;
        private int typeOfUser;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PerformedCargoesMain);

            typeOfUser = Intent.GetIntExtra("TypeOfUser", 1);

            mListView = FindViewById<ListView>(Resource.Id.lstPcPerformed);

            LayoutInflater inflater = (LayoutInflater)this.GetSystemService(Context.LayoutInflaterService);
            View headerView = inflater.Inflate(Resource.Layout.CargoesHeader, null);
            TextView lblTextHeader = (TextView)headerView.FindViewById<TextView>(Resource.Id.lblChTitleList);
            lblTextHeader.SetText(Resource.String.PerformedCargoesTitle);

            View footerView = inflater.Inflate(Resource.Layout.CargoesFooter, null);
            PerformedCargoesAdapter adapter = new PerformedCargoesAdapter(this, mItems);
            mListView.AddHeaderView(headerView);
            mListView.AddFooterView(footerView);
            mListView.Adapter = adapter;

            //var texview = FindViewById<TextView>(Resource.Id.lblChTitleList);
            //texview.Text = "Cargas Realizadas";

            btnVolver = FindViewById<Button>(Resource.Id.btnCfReturn);
            btnVolver.Click += delegate
            {
                Intent nextScreen = new Intent(this, typeof(MainHistoricalActivity));
                nextScreen.PutExtra("TypeOfUser", typeOfUser);
                StartActivity(nextScreen);
            };

        }
    }
}