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
    [Activity(Label = "MainHistoricalActivity", Theme = "@android:style/Theme.NoTitleBar")]
    public class MainHistoricalActivity : Activity
    {
        private Button btnVolver;
        private Button btnCargasRealizadas;
        private Button btnCargasAdjudicadas;
        private Button btnVerReputacion;
        private int typeOfUser;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainHistorical);
            // Create your application here
            InitComponents();

        }

        private void InitComponents()
        {
            typeOfUser = int.Parse(AuthService.UserType);
            btnVolver = FindViewById<Button>(Resource.Id.btnMhReturn);
            btnCargasRealizadas = FindViewById<Button>(Resource.Id.btnMhPerformedCargoes);
            btnCargasAdjudicadas = FindViewById<Button>(Resource.Id.btnMhAwardedCargoes);
            btnVerReputacion = FindViewById<Button>(Resource.Id.btnMhSeeRank);

            btnVolver.Click += BtnVolver_Click;
            btnCargasRealizadas.Click += BtnCargasRealizadas_Click;
            btnCargasAdjudicadas.Click += BtnCargasAdjudicadas_Click;
            btnVerReputacion.Click += BtnVerReputacion_Click;
        }

        private void BtnVerReputacion_Click(object sender, EventArgs e)
        {
           
        }

        private void BtnCargasAdjudicadas_Click(object sender, EventArgs e)
        {
            Intent nextScreen = new Intent(this, typeof(AwardedCargoesActivity));           
            StartActivity(nextScreen);
        }

        private void BtnCargasRealizadas_Click(object sender, EventArgs e)
        {
            Intent nextScreen = new Intent(this, typeof(PerformedCargoesActivity));
            StartActivity(nextScreen);
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            Intent nextScreen = new Intent(this, typeof(LoginUserActivity));
            StartActivity(nextScreen);
        }

       
    }
}