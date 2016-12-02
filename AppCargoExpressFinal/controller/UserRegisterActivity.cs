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
    [Activity(Label = "UserRegisterActivity", Theme = "@android:style/Theme.NoTitleBar")]
    public class UserRegisterActivity : Activity
    {
        private Button btnRegister;
        private Button btnReturn;
        private ProgressDialog progressBar;
        private Spinner spnUrCity;
        private int typeOfUser;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.UserRegister);
            // Create your application here         
            btnRegister = FindViewById<Button>(Resource.Id.btnUrRegister);
            btnReturn = FindViewById<Button>(Resource.Id.btnUrReturn);
            spnUrCity = FindViewById<Spinner>(Resource.Id.sprUrCity);
            ArrayAdapter<string> cityAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, DataModels.DataModels.Cities);
            cityAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spnUrCity.Adapter = cityAdapter;

            btnRegister.Click += BtnRegister_Click;
            btnReturn.Click += BtnReturn_Click;
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            Intent nextScreen = new Intent(this, typeof(MainActivity));
            StartActivity(nextScreen);
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            progressBar = new ProgressDialog(this);
            progressBar.SetCancelable(false);
            progressBar.SetMessage("Registrando...");
            progressBar.SetProgressStyle(ProgressDialogStyle.Spinner);
            progressBar.Show();

            new Thread(new ThreadStart(delegate ()
            {
                Thread.Sleep(2000);//timer for loading  loading de 1000ms (1 seg)
                RunOnUiThread(() => { progressBar.Hide(); });
                RunOnUiThread(() => {
                    Toast.MakeText(this, "Registro Exitoso", ToastLength.Long).Show();
                });
            })).Start();

            new Thread(new ThreadStart(delegate ()
            {
                Thread.Sleep(2000);//timer for loading  loading de 1000ms (1 seg)
                RunOnUiThread(() => { progressBar.Hide(); });
                Intent nextScreen = new Intent(this, typeof(MainActivity));
                StartActivity(nextScreen);
            })).Start();
        }
    }
}