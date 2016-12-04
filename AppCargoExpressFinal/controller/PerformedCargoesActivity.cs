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
    [Activity(Label = "PerformedCargoesActivity", Theme = "@android:style/Theme.NoTitleBar")]
    public class PerformedCargoesActivity : Activity
    {

        private List<PerformedCargoes> mItems = new List<PerformedCargoes>()
        {
            new PerformedCargoes ("Eliecer Lopez","05/11/2016","Pto. Montt - Santiago","Mudanza","$550.000",5),
            new PerformedCargoes ("Cristian Carvajal","06/11/2016","Santiago - Arica","Artículo Hogar","$100.000",4.4f),
            new PerformedCargoes ("Daniel Fuentes","07/11/2016","Coquimbo - Concepción","Industial","$170.000",3),
            new PerformedCargoes ("Julio Toledo","08/11/2016","Concepción - Temuco","Carga Peligrosa","$210.000",2.7f),
            new PerformedCargoes ("Eduardo Oses","15/11/2016","Temuco - Osorno","Vehículos Menores","$80.000",1),
            new PerformedCargoes ("Gabriel Parada","16/11/2016","Osorno - Lanco","Vehículos Mayores","$70.000",4),
            new PerformedCargoes ("Fabián Mondaca","17/11/2016","Lanco - Valdivia","Carga Peligrosa","$100.000",5),
            new PerformedCargoes ("Felipe Chavez","18/11/2016","Valdivia - Pto. Montt","Carga Peligrosa","$230.000",4.5f),
            new PerformedCargoes ("Rubén Guiñez","19/11/2016","Pto. Montt - Chiloé","Artículo Hogar","$50.000",3.8f),
            new PerformedCargoes ("Cristian Ulloa","20/11/2016","Pta. Arenas - Cohyaique","Mudanza","$200.000",4.2f)
        };
        private ListView mListView;
        private Button btnVolver;
        private int typeOfUser;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PerformedCargoesMain);

            typeOfUser = int.Parse(AuthService.UserType);

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
                StartActivity(nextScreen);
            };

        }
    }
}