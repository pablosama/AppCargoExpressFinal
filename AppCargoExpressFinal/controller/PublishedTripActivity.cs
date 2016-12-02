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
   
        private ListView mListView;
        private Button btnVolver;
        private int typeOfUser;
        private TextView lblName;
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
            lblName = FindViewById<TextView>(Resource.Id.txtPcUser);
            mListView.ItemClick += MListView_ItemClick;

            btnVolver.Click += delegate
            {
                Intent nextScreen = new Intent(this, typeof(SearchCargoesActivity));
                StartActivity(nextScreen);
            };

        }

        private void MListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var elementSelected = mListView.GetItemAtPosition(e.Position);
            var usuario = e.View.FindViewById<TextView>(Resource.Id.txtPcUser);
            var fecha = e.View.FindViewById<TextView>(Resource.Id.txtPcDate);
            var originDestiny = e.View.FindViewById<TextView>(Resource.Id.txtPcOriginDestiny);
            var cargoType = e.View.FindViewById<TextView>(Resource.Id.txtPcCargoType);
            var value = e.View.FindViewById<TextView>(Resource.Id.txtPcValue);

            Intent nextScreen = new Intent(this, typeof(PublishedTripConfirmationActivity));
            nextScreen.PutExtra("usuario", usuario.Text);
            nextScreen.PutExtra("fecha", fecha.Text);
            nextScreen.PutExtra("originDestiny", originDestiny.Text);
            nextScreen.PutExtra("cargoType", cargoType.Text);
            nextScreen.PutExtra("value", value.Text);
            StartActivity(nextScreen);
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