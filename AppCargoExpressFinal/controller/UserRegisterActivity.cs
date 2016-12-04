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
            var user = GetFormData();
            var data = new DataModels.DataModels();
            var isValidForm = !string.IsNullOrEmpty(user.alias);
            var isValidUser = false;
            if (isValidForm)
            {
                isValidUser = !data.UserExist(user.alias, user.nombre, user.apellido);
            }
           
            progressBar = new ProgressDialog(this);
            if(isValidForm)
            {
                progressBar.SetCancelable(false);
                progressBar.SetMessage("Validando Cuenta...");
                progressBar.SetProgressStyle(ProgressDialogStyle.Spinner);
                progressBar.Show();
            }         

            new Thread(new ThreadStart(delegate ()
            {
                Thread.Sleep(2000);//timer for loading  loading de 1000ms (1 seg)
                RunOnUiThread(() => { progressBar.Hide(); });
                RunOnUiThread(() => {
                    if(isValidUser)
                    {
                        data.SetUser(user);
                    }
                    Toast.MakeText(this, !isValidForm ? 
                                         "Complete los datos del formulario":
                                         isValidUser? "Registro Exitoso":"El alias y/o usuario ya existe", 
                                         ToastLength.Long).Show();
                });
            })).Start();

            if(isValidForm && isValidUser)
            {
                new Thread(new ThreadStart(delegate ()
                {
                    Thread.Sleep(2000);//timer for loading  loading de 1000ms (1 seg)
                    RunOnUiThread(() => { progressBar.Hide(); });
                    Intent nextScreen = new Intent(this, typeof(MainActivity));
                    StartActivity(nextScreen);
                })).Start();
            }
          
        }

        private DataModels.DataModels.Usuario GetFormData()
        {
            var model = new DataModels.DataModels.Usuario();
            EditText txtName = FindViewById<EditText>(Resource.Id.txtUrUserName);
            EditText txtLastName = FindViewById<EditText>(Resource.Id.txtUrUserLastName);
            EditText txtAlias = FindViewById<EditText>(Resource.Id.txtUrAlias);
            EditText txtPass = FindViewById<EditText>(Resource.Id.txtUrPassword);
            EditText txtMovilPhone = FindViewById<EditText>(Resource.Id.txtUrPhone);
            EditText txtCodArea = FindViewById<EditText>(Resource.Id.txtUrCodArea);
            EditText txtPhone2 = FindViewById<EditText>(Resource.Id.txtUrPhone2);
            EditText txtMail = FindViewById<EditText>(Resource.Id.txtUrMail);
            EditText txtAdress = FindViewById<EditText>(Resource.Id.txtUrAddress);
            Spinner spnCity = FindViewById<Spinner>(Resource.Id.sprUrCity);

            if(!string.IsNullOrEmpty(txtName.Text.Trim()) && !string.IsNullOrEmpty(txtLastName.Text.Trim()) && 
               !string.IsNullOrEmpty(txtAlias.Text.Trim()) && !string.IsNullOrEmpty(txtMovilPhone.Text.Trim()) &&
               !string.IsNullOrEmpty(txtMail.Text.Trim()) && !string.IsNullOrEmpty(txtAdress.Text.Trim()) &&
               !string.IsNullOrEmpty(txtPass.Text.Trim()))
            {
                model = new DataModels.DataModels.Usuario(txtAlias.Text, txtPass.Text,txtName.Text, txtLastName.Text, 1,txtMovilPhone.Text, txtCodArea.Text, txtMail.Text, spnUrCity.SelectedItem.ToString(), txtAdress.Text, DateTime.Now, DateTime.Now,txtPhone2.ToString());
            }

            return model;
        }
    }
}