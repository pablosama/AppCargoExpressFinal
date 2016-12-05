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
    [Activity(Label = "PublishedTripConfirmationActivity", Theme = "@android:style/Theme.NoTitleBar")]
    public class PublishedTripConfirmationActivity : Activity
    {
        private TextView lblUser;
        private TextView lblDate;
        private TextView lblOriginDestiny;
        private TextView lblCargoType;
        private TextView lblPrice;
        private Button btnConfirm;
        private Button btnReturn;
        private TextView lblInfo;
        private int typeOfUser;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PublishedTripConfirmation);
            InitComponents();
        }

        private void InitComponents()
        {
            typeOfUser = int.Parse(AuthService.UserType);
            btnReturn = FindViewById<Button>(Resource.Id.btnPtcReturn);
            btnConfirm = FindViewById<Button>(Resource.Id.btnPtcConfirm);

            var originDestiny = Intent.GetStringExtra("originDestiny");
            var fecha = Intent.GetStringExtra("fecha");
            var usuario = Intent.GetStringExtra("usuario");
            var cargoType = Intent.GetStringExtra("cargoType");
            var value = Intent.GetStringExtra("value");

            lblUser = FindViewById<TextView>(Resource.Id.txtPtcUser);
            lblDate = FindViewById<TextView>(Resource.Id.txtPtcDate);
            lblOriginDestiny = FindViewById<TextView>(Resource.Id.txtPtcOriginDestiny);
            lblCargoType = FindViewById<TextView>(Resource.Id.txtPtcCargoType);
            lblPrice = FindViewById<TextView>(Resource.Id.txtPtcValue);

            lblInfo = FindViewById<TextView>(Resource.Id.txtPtcInfo);
            lblInfo.Text = typeOfUser == 1 ? "Está a punto de adjudicarse el viaje indicado, ¿desea continuar?" : "Está a punto de adjudicarse la carga indicada, ¿desea continuar?";

            lblUser.Text = usuario;
            lblDate.Text = fecha;
            lblOriginDestiny.Text = originDestiny;
            lblCargoType.Text = cargoType;
            lblPrice.Text = value;

            btnConfirm.Click += BtnConfirm_Click;
            btnReturn.Click += BtnReturn_Click;
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            Intent nextScreen = new Intent(this, typeof(SearchCargoesActivity));
            StartActivity(nextScreen);
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            var title = "¡¡Felicitaciones!!";
            var message = typeOfUser == 1 ? "Acabas de adjudicarte el viaje, en unos momentos nuestros ejecutivos se contactarán con usted" :"Acabas de adjudicarte la carga, en unos momentos nuestros ejecutivos se contactarán con usted";
            ShowAlert(title, message);
        }

        private void ShowAlert(string title, string message)
        {
            Android.App.AlertDialog.Builder builder = new AlertDialog.Builder(this);
            AlertDialog alertDialog = builder.Create();
            alertDialog.SetTitle(title);
            alertDialog.SetIcon(Android.Resource.Drawable.IcDialogAlert);
            alertDialog.SetMessage(message);
            alertDialog.SetButton("Aceptar", (s, ev) => {
                Intent nextScreen = new Intent(this, typeof(SearchCargoesActivity));
                StartActivity(nextScreen);
            });
            alertDialog.Show();
        }
    }
}