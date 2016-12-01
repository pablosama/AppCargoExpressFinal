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
    [Activity(Label = "SearchCargoesActivity")]
    public class SearchCargoesActivity : Activity
    {
        private Button btnSearch;
        private Button btnReturn;
        private Button btnClean;
        private Spinner spnOrigin;
        private Spinner spnDestiny;
        private int typeOfUser;
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.SearchCargoes);
            typeOfUser = Intent.GetIntExtra("TypeOfUser", 1);

            spnOrigin = FindViewById<Spinner>(Resource.Id.sprScOrigin);
            spnDestiny = FindViewById<Spinner>(Resource.Id.sprScDestiny);

            ArrayAdapter<string> dataAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem,DataModels.DataModels.Cities);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            spnOrigin.Adapter = dataAdapter;
            spnDestiny.Adapter = dataAdapter;

            btnSearch = FindViewById<Button>(Resource.Id.btnScSearch);
            btnClean = FindViewById<Button>(Resource.Id.btnScClean);
            btnReturn = FindViewById<Button>(Resource.Id.btnScReturn);

            btnReturn.Click += BtnReturn_Click;
            btnSearch.Click += BtnSearch_Click;

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            Intent nextScreen = new Intent(this, typeof(PerformedCargoesActivity));
            nextScreen.PutExtra("TypeOfUser", typeOfUser);
            StartActivity(nextScreen);
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            Intent nextScreen = new Intent(this, typeof(LoginUserActivity));
            nextScreen.PutExtra("TypeOfUser", typeOfUser);
            StartActivity(nextScreen);
        }
    }
}