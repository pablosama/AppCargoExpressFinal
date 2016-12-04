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
    [Activity(Label = "LoginUser", Theme = "@android:style/Theme.NoTitleBar")]
    public class LoginUserActivity : Activity
    {
        private Button btnVolver;
        private Button btnModificarRegistro;
        private Button btnPublicarCarga;
        private Button btnHistorial;
        private TextView txtWelcomeUser;
        private Button btnBuscarViaje;
        private Button btnBuscarCarga;
        
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
            typeOfUser = int.Parse(AuthService.UserType);
            txtWelcomeUser = FindViewById<TextView>(Resource.Id.txtLUAWelcomeUser);
            txtWelcomeUser.Text = txtWelcomeUser.Text + " " + AuthService.Name ?? "Desconocido";

            btnVolver = FindViewById<Button>(Resource.Id.btnLUAReturn);
            btnModificarRegistro = FindViewById<Button>(Resource.Id.btnLUAModifyRegister);
            btnPublicarCarga = FindViewById<Button>(Resource.Id.btnLUAPublishCargo);
            btnHistorial = FindViewById<Button>(Resource.Id.btnLUAHistorical);
            btnBuscarViaje = FindViewById<Button>(Resource.Id.btnLUASearchTravel);
            btnBuscarCarga = FindViewById<Button>(Resource.Id.btnLUASearchCargo);

            btnVolver.Click += BtnVolver_Click;
            btnModificarRegistro.Click += BtnModificarRegistro_Click;
            btnBuscarViaje.Click += BtnBuscarViaje_Click;
            btnBuscarCarga.Click += BtnBuscarCarga_Click;
            btnHistorial.Click += BtnHistorial_Click;
            btnPublicarCarga.Click += BtnPublicarCarga_Click;
        }

        private void BtnPublicarCarga_Click(object sender, EventArgs e)
        {
            Intent nextScreen = new Intent(this, typeof(CargoesPublishActivity));
            StartActivity(nextScreen);
        }

        private void BtnBuscarCarga_Click(object sender, EventArgs e)
        {
            Intent nextScreen = new Intent(this, typeof(SearchCargoesActivity));            
            StartActivity(nextScreen);
        }

        private void BtnBuscarViaje_Click(object sender, EventArgs e)
        {
            Intent nextScreen = new Intent(this, typeof(SearchCargoesActivity));          
            StartActivity(nextScreen);
        }

        private void BtnHistorial_Click(object sender, EventArgs e)
        {
            Intent nextScreen = new Intent(this, typeof(MainHistoricalActivity));           
            StartActivity(nextScreen);
        }


        private void BtnModificarRegistro_Click(object sender, EventArgs e)
        {
            Intent nextScreen = new Intent(this, typeof(ModifyUserActivity));
            StartActivity(nextScreen);
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            AuthService.DeleteCredentials();

            Intent nextScreen = new Intent(this, typeof(MainActivity));
            StartActivity(nextScreen);
        }

        private void SelectButtonsToDisplay(int typeOfUser)
        {
            switch (typeOfUser)
            {
                case 1:
                    btnBuscarViaje.Visibility = ViewStates.Gone;
                    break;
                case 2:
                    btnPublicarCarga.Visibility = ViewStates.Gone;
                    btnBuscarCarga.Visibility = ViewStates.Gone;
                    break;
            }
        }
    }
}