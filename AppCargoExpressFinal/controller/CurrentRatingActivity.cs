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
    [Activity(Label = "CurrentRatingActivity", Theme = "@android:style/Theme.NoTitleBar")]
    public class CurrentRatingActivity : Activity
    {
        Button btnReturn;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.UserCurrentRating);

            TextView txtUser = FindViewById<TextView>(Resource.Id.txtUcrUser);
            txtUser.Text = AuthService.Name + " " + AuthService.LastName;

            TextView txtNumEv = FindViewById<TextView>(Resource.Id.txtUcrNumEv);
            txtNumEv.Text = AuthService.EvaluationsNumber.ToString();

            RatingBar rtgCurrentRating = FindViewById<RatingBar>(Resource.Id.rtgUcrRating);
            rtgCurrentRating.Rating = 4.1f;
            rtgCurrentRating.Enabled = false;

            btnReturn = FindViewById<Button>(Resource.Id.btnUcrReturn);

            btnReturn.Click += BtnReturn_Click;
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            Intent nextScreen = new Intent(this, typeof(MainHistoricalActivity));
            StartActivity(nextScreen);
        }
    }
}