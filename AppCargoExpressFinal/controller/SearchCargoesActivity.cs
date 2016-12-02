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
using System.Threading;

namespace AppCargoExpressFinal.controller
{
    [Activity(Label = "SearchCargoesActivity", Theme = "@android:style/Theme.NoTitleBar")]
    public class SearchCargoesActivity : Activity
    {
        private Button btnSearch;
        private Button btnReturn;
        private Button btnClean;
        private Spinner spnOrigin;
        private Spinner spnDestiny;
        private Spinner spnCargoType;
        private Spinner spnPriceRange;
        private int typeOfUser;
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SearchCargoes);

            InitComponents();
            InitEvents();

        }

       

        private void InitComponents()
        {
            typeOfUser = int.Parse(AuthService.UserType);

            spnOrigin = FindViewById<Spinner>(Resource.Id.sprScOrigin);
            spnDestiny = FindViewById<Spinner>(Resource.Id.sprScDestiny);
            spnCargoType = FindViewById<Spinner>(Resource.Id.sprScCargoType);
            spnPriceRange = FindViewById<Spinner>(Resource.Id.sprScPriceRange);

            ArrayAdapter<string> cityAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, DataModels.DataModels.Cities);
           
            cityAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spnOrigin.Adapter = cityAdapter;
            spnDestiny.Adapter = cityAdapter;

            ArrayAdapter<string> cargoTypeAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, DataModels.DataModels.CargoTypes.Select(o => o.Value).ToList());
            cargoTypeAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spnCargoType.Adapter = cargoTypeAdapter;
            ArrayAdapter<string> priceRangeAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, DataModels.DataModels.PriceRangeAndId.Select(o => o.Value).ToList());
            priceRangeAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spnPriceRange.Adapter = priceRangeAdapter;

            btnSearch = FindViewById<Button>(Resource.Id.btnScSearch);
            btnClean = FindViewById<Button>(Resource.Id.btnScClean);
            btnReturn = FindViewById<Button>(Resource.Id.btnScReturn);
        }

        private void InitEvents()
        {
            btnReturn.Click += BtnReturn_Click;
            btnClean.Click += BtnClean_Click;
            btnSearch.Click += BtnSearch_Click;
        }

        private void BtnClean_Click(object sender, EventArgs e)
        {

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            var originValue = spnOrigin.SelectedItem.ToString();
            var destinyValue = spnDestiny.SelectedItem.ToString();
            var cargoTypeValue = spnCargoType.SelectedItem.ToString();
            var priceRangeValue = spnPriceRange.SelectedItem.ToString();

            Intent nextScreen = new Intent(this, typeof(PublishedTripActivity));
            nextScreen.PutExtra("originValue", originValue);
            nextScreen.PutExtra("destinyValue", destinyValue);
            nextScreen.PutExtra("cargoTypeValue", cargoTypeValue);
            nextScreen.PutExtra("priceRangeValue", priceRangeValue);
            StartActivity(nextScreen);

        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            Intent nextScreen = new Intent(this, typeof(LoginUserActivity));          
            StartActivity(nextScreen);
        }
    }
}