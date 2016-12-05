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
using Android.Graphics;

namespace AppCargoExpressFinal.controller
{
    [Activity(Label = "ModifyUserActivity", Theme = "@android:style/Theme.NoTitleBar")]
    public class ModifyUserActivity : Activity
    {
        private Button btnRegister;
        private Button btnReturn;
        private ProgressDialog progressBar;      
        private int typeOfUser;
        private EditText txtName;
        private EditText txtLastName;
        private EditText txtAlias;
        private EditText txtPass;
        private EditText txtMovilPhone;
        private EditText txtCodArea;
        private EditText txtPhone2;
        private EditText txtMail;
        private EditText txtAdress;
        private TextView lblLicenceNumber;
        private TextView lblTypeOfTruck;
        private EditText txtLicenceNumber;
        private Spinner spnCity;
        private Spinner spnTypeOfTruck;
        private TextView lblTitle;

        private DataModels.DataModels.Usuario currentUser;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.UserRegister);
            // Create your application here      
            var user = new DataModels.DataModels();
            currentUser = AuthService.GetCredentials();//user.GetUser(AuthService.Alias, AuthService.Password);

            SetUserData();

            btnRegister.Click += BtnRegister_Click;
            btnReturn.Click += BtnReturn_Click;
        }

        public void SetUserData()
        {
            typeOfUser = int.Parse(AuthService.UserType);
            btnRegister = FindViewById<Button>(Resource.Id.btnUrRegister);
            btnRegister.Text = "Modificar";
            btnReturn = FindViewById<Button>(Resource.Id.btnUrReturn);
            spnCity = FindViewById<Spinner>(Resource.Id.sprUrCity);

            lblLicenceNumber = FindViewById<TextView>(Resource.Id.lblUrLicenceNumber);
            lblTypeOfTruck = FindViewById<TextView>(Resource.Id.lblUrTypeOfTruck);
            lblTitle = FindViewById<TextView>(Resource.Id.lblUrTitle);
            txtLicenceNumber = FindViewById<EditText>(Resource.Id.txtUrLicenceNumber);
            spnTypeOfTruck = FindViewById<Spinner>(Resource.Id.sprUrTypeOfTruck);
            txtName = FindViewById<EditText>(Resource.Id.txtUrUserName);
            txtLastName = FindViewById<EditText>(Resource.Id.txtUrUserLastName);
            txtAlias = FindViewById<EditText>(Resource.Id.txtUrAlias);
            txtPass = FindViewById<EditText>(Resource.Id.txtUrPassword);
            txtMovilPhone = FindViewById<EditText>(Resource.Id.txtUrPhone);
            txtCodArea = FindViewById<EditText>(Resource.Id.txtUrCodArea);
            txtPhone2 = FindViewById<EditText>(Resource.Id.txtUrPhone2);
            txtMail = FindViewById<EditText>(Resource.Id.txtUrMail);
            txtAdress = FindViewById<EditText>(Resource.Id.txtUrAddress);
            spnCity = FindViewById<Spinner>(Resource.Id.sprUrCity);

            if (typeOfUser == 1)
            {
                lblLicenceNumber.Visibility = ViewStates.Gone;
                lblTypeOfTruck.Visibility = ViewStates.Gone;
                txtLicenceNumber.Visibility = ViewStates.Gone;
                spnTypeOfTruck.Visibility = ViewStates.Gone;
                lblTitle.Text = "Formulario Modificación Usuario";
            }
            else
            {
                ArrayAdapter<string> truckTypeAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, DataModels.DataModels.TruckTypes.Select(o => o.Value).ToList());
                truckTypeAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
                spnTypeOfTruck.Adapter = truckTypeAdapter;
                lblTitle.Text = "Formulario Modificación Transportista";
                spnTypeOfTruck.SetSelection(truckTypeAdapter.GetPosition(currentUser.typOfVehicle));
                txtLicenceNumber.Text = currentUser.licenceNumber;
            }

            ArrayAdapter<string> cityAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, DataModels.DataModels.Cities);
            cityAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spnCity.Adapter = cityAdapter;
            spnCity.SetSelection(cityAdapter.GetPosition(currentUser.comuna));

            txtLicenceNumber.Text = currentUser.licenceNumber;
            txtName.Text = currentUser.nombre;
            DisableFields(txtName);
            txtLastName.Text = currentUser.apellido;
            DisableFields(txtLastName);
            txtAlias.Text = currentUser.alias;
            DisableFields(txtAlias);

            txtPass.Text = currentUser.contrasena;
            txtMovilPhone.Text = currentUser.telefonoMovil;
            txtPhone2.Text = currentUser.telefonoFijo;
            txtCodArea.Text = currentUser.codigoArea;
            txtMail.Text = currentUser.mail;
            txtAdress.Text = currentUser.direccion;

        }

        private void DisableFields(EditText editText)
        {
            editText.Focusable = false;
            editText.Enabled = false;
            editText.SetCursorVisible(false);
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            Intent nextScreen = new Intent(this, typeof(LoginUserActivity));
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
                isValidUser = data.UserExist(user.alias, user.nombre, user.apellido);
            }

            progressBar = new ProgressDialog(this);
            if (isValidForm)
            {
                progressBar.SetCancelable(false);
                progressBar.SetMessage("Validando Cuenta...");
                progressBar.SetProgressStyle(ProgressDialogStyle.Spinner);
                progressBar.Show();
            }

            new Thread(new ThreadStart(delegate ()
            {
                Thread.Sleep(2000);//timer for loading  loading de 2000ms (1 seg)
                RunOnUiThread(() => { progressBar.Hide(); });
                RunOnUiThread(() => {
                    data.SetUser(user);
                    user.cantidadEvaluaciones = currentUser.cantidadEvaluaciones;
                    user.ranking = currentUser.ranking;
                    AuthService.SaveCredentials(user);
                                 
                    if(!isValidUser)
                    {
                        Toast.MakeText(this, "Complete los datos del formulario", ToastLength.Long).Show();
                    }
                    else
                    {
                        ShowAlert("¡Felicidades!","Ha actualizado sus datos correctamente");
                    }            
                });
            })).Start();

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


            if (!string.IsNullOrEmpty(txtName.Text.Trim()) && !string.IsNullOrEmpty(txtLastName.Text.Trim()) &&
               !string.IsNullOrEmpty(txtAlias.Text.Trim()) && !string.IsNullOrEmpty(txtMovilPhone.Text.Trim()) &&
               !string.IsNullOrEmpty(txtMail.Text.Trim()) && !string.IsNullOrEmpty(txtAdress.Text.Trim()) &&
               !string.IsNullOrEmpty(txtPass.Text.Trim()))
            {
                model = new DataModels.DataModels.Usuario(
                    txtAlias.Text,
                    txtPass.Text,
                    txtName.Text,
                    txtLastName.Text,
                    typeOfUser,
                    txtMovilPhone.Text,
                    txtCodArea.Text,
                    txtMail.Text,
                    spnCity.SelectedItem.ToString(),
                    txtAdress.Text,
                    DateTime.Now,
                    DateTime.Now,
                    txtPhone2.Text,
                    currentUser.cantidadEvaluaciones,
                    typeOfUser == 2 ? txtLicenceNumber.Text : "",
                    typeOfUser == 2 ? spnTypeOfTruck.SelectedItem.ToString() : "",
                    currentUser.ranking);
            }

            return model;
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