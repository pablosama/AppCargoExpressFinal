using Android.App;
using Android.Widget;
using Android.OS;
using System.Threading;
using System;
using System.Linq;
using Android.Content;
using AppCargoExpressFinal.controller;
using Xamarin.Auth;
using Android.Views;
using System.Collections.Generic;

namespace AppCargoExpressFinal.controller
{
    [Activity(Label = "AppCargo", MainLauncher = true, Icon = "@drawable/icon", Theme = "@android:style/Theme.NoTitleBar")]
    public class MainActivity : Activity
    {

        private Button btnLogin;
        private Button btnLogout;
        private EditText txtUserName;
        private EditText txtPass;
        private TextView lblRegister;
        //private UserServiceWebReference.UserDto miUsuario = new UserServiceWebReference.UserDto();
        private ProgressDialog progressBar;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            txtUserName = FindViewById<EditText>(Resource.Id.txtMUserName);
            lblRegister = FindViewById<TextView> (Resource.Id.lblMRegister);

            lblRegister.Click += new EventHandler(this.RegisterOnClick);

            btnLogin = FindViewById<Button>(Resource.Id.btnMLogin);
            btnLogin.Click += BtnLogin_Click;

            btnLogout = FindViewById<Button>(Resource.Id.btnMLogout);
            btnLogout.Click += BtnLogout_Click;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            var txtLogin = FindViewById<EditText>(Resource.Id.txtMUserName);
            var txtPass = FindViewById<EditText>(Resource.Id.txtMPassword);
            DisplayProgressLoading(txtLogin.Text, txtPass.Text);
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.FinishAffinity();
        }
   

        //modal for upload/download data
        private void DisplayProgressBar()
        {
            var progressBar = new ProgressDialog(this);
            progressBar.SetCancelable(true);
            progressBar.SetMessage("Cargando...");
            progressBar.SetProgressStyle(ProgressDialogStyle.Horizontal);
            progressBar.Progress = 0;
            progressBar.Max = 100;
            progressBar.Show();
            var progressBarStatus = 0;

            new Thread(new ThreadStart(delegate ()
            {
                while (progressBarStatus < 100)
                {
                    progressBarStatus += 1;
                    progressBar.Progress += progressBarStatus;
                    Thread.Sleep(100);//timer for display loaging
                }
                RunOnUiThread(() => { progressBar.SetMessage("carga completa"); });
                RunOnUiThread(() => { Toast.MakeText(this, "archivo descargado", ToastLength.Long).Show(); });
            })).Start();
        }

        //Modal for show  loading...
        private void DisplayProgressLoading(string user, string pass)
        {
            try
            {
                bool check = true;//NetworkInterface.GetIsNetworkAvailable(); comment this line because 
                if (check)
                {
                    progressBar = new ProgressDialog(this);
                    progressBar.SetCancelable(false);
                    progressBar.SetMessage("Accediendo...");
                    progressBar.SetProgressStyle(ProgressDialogStyle.Spinner);
                    progressBar.Show();
                  
                    var dataModels = new DataModels.DataModels();
                    var userValid = dataModels.UserExist(user, string.Empty, string.Empty);                                

                    new Thread(new ThreadStart(delegate ()
                    {
                        Thread.Sleep(2000);//timer for loading of 2000ms 
                        RunOnUiThread(() => { progressBar.Hide(); });
                        RunOnUiThread(() => { Toast.MakeText(this, userValid?"Acceso Exitoso":"Usuario y/o Contraseña incorrecto", ToastLength.Long).Show();                      
                        });
                    })).Start();
                 
                    if(userValid)
                    {
                        new Thread(new ThreadStart(delegate ()
                        {
                            Thread.Sleep(2000);//timer for loading of 23000ms 
                            RunOnUiThread(() => { progressBar.Hide(); });
                            RunOnUiThread(() => {
                                //Sending data to another Activity
                                //TODO: here add service conection for user validation
                                //if is correct then save the credencials in app
                                var userData = dataModels.GetUser(user, pass);
                                AuthService.SaveCredentials(userData.alias, userData.contrasena, userData.nombre, userData.tipoUsuario);
                                Intent nextScreen = new Intent(this, typeof(LoginUserActivity));                                                         
                                StartActivity(nextScreen);
                            });
                        })).Start();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RegisterOnClick(Object sender, EventArgs e)
        {
            Intent nextScreen = new Intent(this, typeof(PreSelectRegisterActivity));
            StartActivity(nextScreen);
        }

    }
}
