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
using Android.Graphics;

namespace AppCargoExpressFinal.controller
{
    [Activity(Label = "PreSelectRegisterActivity", Theme = "@android:style/Theme.NoTitleBar")]
    public class PreSelectRegisterActivity : Activity
    {
        private Button btnUser;
        private Button btnCarrier;
        private TextView lblInfoAfterSelect;
        private Button btnIngresar;
        private Button btnVolver;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PreSelectionRegister);
            // Create your application here
            btnUser = FindViewById<Button>(Resource.Id.btnPSRUser);
            btnCarrier = FindViewById<Button>(Resource.Id.btnPSRCarrier);
            lblInfoAfterSelect = FindViewById<TextView>(Resource.Id.lblPSRSelectUserMsg);
            btnIngresar = FindViewById<Button>(Resource.Id.btnPSRIngresar);
            btnIngresar.Visibility = ViewStates.Invisible;
            btnVolver = FindViewById<Button>(Resource.Id.btnPSRReturn);

            btnUser.Click += BtnUser_Click;
            btnCarrier.Click += BtnCarrier_Click;
            btnIngresar.Click += BtnIngresar_Click;
            btnVolver.Click += BtnVolver_Click;
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            Intent nextScreen = new Intent(this, typeof(MainActivity));
            StartActivity(nextScreen);
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            Intent nextScreen = new Intent(this, typeof(UserRegisterActivity));
            StartActivity(nextScreen);
        }

        private void BtnCarrier_Click(object sender, EventArgs e)
        {
            //lblInfoAfterSelect.Visibility = ViewStates.Invisible;
            lblInfoAfterSelect.Text = "has seleccionado Transportista";
            btnIngresar.Visibility = ViewStates.Visible;
        }

        private void BtnUser_Click(object sender, EventArgs e)
        {
            // lblInfoAfterSelect.Visibility = ViewStates.Invisible;
            lblInfoAfterSelect.Text = "has seleccionado Usuario";
            btnIngresar.Visibility = ViewStates.Visible;
           
        }
    }
}