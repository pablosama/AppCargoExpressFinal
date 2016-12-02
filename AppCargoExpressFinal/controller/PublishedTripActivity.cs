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
    [Activity(Label = "PublishedTripActivity", Theme = "@android:style/Theme.NoTitleBar")]
    public class PublishedTripActivity : Activity
    {
        //private List<PerformedCargoes> mItems = new List<PerformedCargoes>()
        //{
        //    new PerformedCargoes ("Armando Casas","05/11/2016","Pto. Montt - Santiago","Mudanza","$300.000"),
        //    new PerformedCargoes ("Julio Rodriguez","06/11/2016","Santiago - Arica","Artículo Hogar","$100.000"),
        //    new PerformedCargoes ("Beto Cuevas","07/11/2016","Coquimbo - Concepción","Industial","$190.000"),
        //    new PerformedCargoes ("Arturo Prat","08/11/2016","Concepción - Temuco","Carga Peligrosa","$210.000"),
        //    new PerformedCargoes ("Pablo Neruda","16/11/2016","Osorno - Lanco","Vehículos Mayores","$90.000"),
        //    new PerformedCargoes ("Eduardo Oses","15/11/2016","Concepción - Temuco","Vehículos Menores","$80.000"),
        //    new PerformedCargoes ("Daniel Fuentes","15/11/2016","Concepción - Temuco","Vehículos Menores","$100.000"),
        //    new PerformedCargoes ("Esteban Sepúlveda","17/11/2016","Lanco - Valdivia","Carga Peligrosa","$50.000"),
        //    new PerformedCargoes ("Marcos Gutierrez","18/11/2016","Valdivia - Pto. Montt","Carga Peligrosa","$230.000"),
        //    new PerformedCargoes ("Rodrigo Campos","19/11/2016","Pto. Montt - Chiloé","Artículo Hogar","$50.000"),
        //    new PerformedCargoes ("Renier Gonzalez","20/11/2016","Pta. Arenas - Cohyaique","Mudanza","$200.000")
        //};
        private ListView mListView;
        private Button btnVolver;
        private int typeOfUser;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PerformedCargoesMain);

            typeOfUser = int.Parse(AuthService.UserType);

            mListView = FindViewById<ListView>(Resource.Id.lstPcPerformed);


            var originValue = Intent.GetStringExtra("originValue");
            var destinyValue = Intent.GetStringExtra("destinyValue");
            var cargoTypeValue = Intent.GetStringExtra("cargoTypeValue");
            var priceRangeValue = Intent.GetStringExtra("priceRangeValue");


            LayoutInflater inflater = (LayoutInflater)this.GetSystemService(Context.LayoutInflaterService);
            View headerView = inflater.Inflate(Resource.Layout.CargoesHeader, null);
            TextView lblTextHeader = (TextView)headerView.FindViewById<TextView>(Resource.Id.lblChTitleList);
            lblTextHeader.SetText(Resource.String.PublishedTripTitle);

            View footerView = inflater.Inflate(Resource.Layout.CargoesFooter, null);
            var data = new DataModels.DataModels();

            var mItems = GetTrips(originValue, destinyValue, cargoTypeValue, priceRangeValue);
            PerformedCargoesAdapter adapter = new PerformedCargoesAdapter(this, mItems);
            mListView.AddHeaderView(headerView);
            mListView.AddFooterView(footerView);
            mListView.Adapter = adapter;

            btnVolver = FindViewById<Button>(Resource.Id.btnCfReturn);
            btnVolver.Click += delegate
            {
                Intent nextScreen = new Intent(this, typeof(SearchCargoesActivity));
                StartActivity(nextScreen);
            };
        }

            public List<PerformedCargoes> GetTrips(string originValue, string destinyValue, string cargoTypeValue, string priceRangeValue)
            {

                var allCargoType = DataModels.DataModels.CargoTypes.FirstOrDefault(o => o.Key == 7).Value;

                var range = DataModels.DataModels.PriceRangeAndId.FirstOrDefault(o => o.Value == priceRangeValue).Key;

                var rangeValues = range.Split(',').Select(int.Parse).ToList();

                var list = DataModels.DataModels.mItems;

                var list1 = list.Where(o => rangeValues.Count() == 2 ? o.getIntMonto() >= rangeValues[0] && o.getIntMonto() <= rangeValues[1] : o.getIntMonto() >= rangeValues[0]).ToList();
           
                var list2 = list1.Where(o => o.origenDestino.StartsWith(originValue) && o.origenDestino.EndsWith(destinyValue)
                                        && (cargoTypeValue == allCargoType ? 1 == 1 : o.tipoCarga == cargoTypeValue)).ToList();
      
                return list2;
            }

    
    }
}