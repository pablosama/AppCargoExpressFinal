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
    [Activity(Label = "LoginUser")]
    public class LoginUserActivity : Activity
    {
        private Button btnVolver;
        private Button btnModificarRegistro;
        private Button btnPublicarCarga;
        private Button btnPublicarViaje;
        private Button btnHistorial;
        private TextView txtWelcomeUser;
        
        private int typeOfUser;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LoginUser);
            // Create your application here
            InitComponents();

            SelectButtonsToDisplay(typeOfUser);
        }

        private void InitComponents()
        {
            typeOfUser = Intent.GetIntExtra("TypeOfUser", 1);
            txtWelcomeUser = FindViewById<TextView>(Resource.Id.txtLUAWelcomeUser);
            txtWelcomeUser.Text = txtWelcomeUser.Text + " " + Intent.GetStringExtra("userName") ?? "Default User";

            btnVolver = FindViewById<Button>(Resource.Id.btnLUAReturn);
            btnModificarRegistro = FindViewById<Button>(Resource.Id.btnLUAModifyRegister);
            btnPublicarCarga = FindViewById<Button>(Resource.Id.btnLUAPublishCargo);
            btnPublicarViaje = FindViewById<Button>(Resource.Id.btnLUAPublishTravel);
            btnHistorial = FindViewById<Button>(Resource.Id.btnLUAHistorical);

            btnVolver.Click += BtnVolver_Click;
            btnModificarRegistro.Click += BtnModificarRegistro_Click;
            btnPublicarCarga.Click += BtnPublicarCarga_Click;
            btnPublicarViaje.Click += BtnPublicarViaje_Click;
            btnHistorial.Click += BtnHistorial_Click;
        }

        private void BtnHistorial_Click(object sender, EventArgs e)
        {
            //todo: add userType
            Intent nextScreen = new Intent(this, typeof(MainHistoricalActivity));
            StartActivity(nextScreen);
        }

        private void BtnPublicarViaje_Click(object sender, EventArgs e)
        {

        }

        private void BtnPublicarCarga_Click(object sender, EventArgs e)
        {

        }

        private void BtnModificarRegistro_Click(object sender, EventArgs e)
        {

        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            //var main = new MainActivity();
            AuthService.DeleteCredentials();

            Intent nextScreen = new Intent(this, typeof(MainActivity));
            StartActivity(nextScreen);
        }

        private void SelectButtonsToDisplay(int typeOfUser)
        {
            switch (typeOfUser)
            {
                case 1:
                    btnPublicarViaje.Visibility = ViewStates.Gone;
                    break;
                case 2:
                    btnPublicarCarga.Visibility = ViewStates.Gone;
                    break;
                case 3:
                    //here put admin buttons  
                    break;
            }
        }
    }
}