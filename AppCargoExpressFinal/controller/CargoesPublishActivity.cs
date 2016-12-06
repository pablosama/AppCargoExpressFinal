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
    [Activity(Label = "CargoesPublishActivity", Theme = "@android:style/Theme.NoTitleBar")]
    public class CargoesPublishActivity : Activity
    {
        private Button btnPublish;
        private Button btnReturn;
        private Spinner spnOrigin;
        private Spinner spnDestiny;
        private Spinner spnCargoType;
        private Spinner spnPriceRange;
        private TextView lblTitle;
        private int typeOfUser;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CargoesPublish);
            // Create your application here    
            InitComponents();
            InitEvents();
           
        }

        public void InitEvents()
        {
            btnPublish.Click += BtnPublish_Click;
            btnReturn.Click += BtnReturn_Click1;
        }

        private void BtnReturn_Click1(object sender, EventArgs e)
        {
            Intent nextScreen = new Intent(this, typeof(LoginUserActivity));
            StartActivity(nextScreen);
        }

        private void BtnPublish_Click(object sender, EventArgs e)
        {
            string title = "¡FELICITACIONES!";
            string message = typeOfUser == 1 ?"Has publicado la carga": "Has publicado un viaje";
            ShowAlert(title, message);
        }

        public void InitComponents()
        {
            typeOfUser = int.Parse(AuthService.UserType);

            spnOrigin = FindViewById<Spinner>(Resource.Id.sprCpOrigin);
            spnDestiny = FindViewById<Spinner>(Resource.Id.sprCpDestiny);
            spnCargoType = FindViewById<Spinner>(Resource.Id.sprCpCargoType);
            spnPriceRange = FindViewById<Spinner>(Resource.Id.sprCpPriceRange);
            lblTitle = FindViewById<TextView>(Resource.Id.lblCpTitle);

            lblTitle.Text = typeOfUser == 1 ? "PUBLICAR CARGA":"PUBLICAR VIAJE";

            ArrayAdapter <string> cityAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, DataModels.DataModels.Cities);

            cityAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spnOrigin.Adapter = cityAdapter;
            spnDestiny.Adapter = cityAdapter;

            ArrayAdapter<string> cargoTypeAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, DataModels.DataModels.CargoTypes.Select(o => o.Value).ToList());
            cargoTypeAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spnCargoType.Adapter = cargoTypeAdapter;
            ArrayAdapter<string> priceRangeAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, DataModels.DataModels.PriceRangeAndId.Select(o => o.Value).ToList());
            priceRangeAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spnPriceRange.Adapter = priceRangeAdapter;

            btnPublish = FindViewById<Button>(Resource.Id.btnCpPublish);
            btnReturn = FindViewById<Button>(Resource.Id.btnCpReturn);
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            Intent nextScreen = new Intent(this, typeof(MainActivity));
            StartActivity(nextScreen);
        }

        private void ShowAlert(string title, string message)
        {
            Android.App.AlertDialog.Builder builder = new AlertDialog.Builder(this);
            AlertDialog alertDialog = builder.Create();
            alertDialog.SetTitle(title);
            alertDialog.SetIcon(Android.Resource.Drawable.IcDialogAlert);
            alertDialog.SetMessage(message);
            alertDialog.SetButton("Aceptar", (s, ev) => {
                Intent nextScreen = new Intent(this, typeof(LoginUserActivity));
                StartActivity(nextScreen);
            });
            alertDialog.Show();
        }

    }
}