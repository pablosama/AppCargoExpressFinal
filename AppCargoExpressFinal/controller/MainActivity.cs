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

namespace AppCargoExpressFinal.controller
{
    [Activity(Label = "AppCargo", MainLauncher = true, Icon = "@drawable/icon")]
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
            //http://localhost:12276/Service1.svc
            //service1.Service1 service = new service1.Service1();
            //service.GetDataAsync(10, true);
            //service.GetDataCompleted += Service_GetDataCompleted;
            //test.GetDataAsync(1, true);
            //test.GetDataCompleted += Test_GetDataCompleted;
        }

        //private void Service_GetDataCompleted(object sender, service1.GetDataCompletedEventArgs e)
        //{
        //    var hola = e.Result;
        //}

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
                bool check = true;//NetworkInterface.GetIsNetworkAvailable();
                if (check)
                {
                    progressBar = new ProgressDialog(this);
                    progressBar.SetCancelable(false);
                    progressBar.SetMessage("Accediendo...");
                    progressBar.SetProgressStyle(ProgressDialogStyle.Spinner);
                    progressBar.Show();

                    new Thread(new ThreadStart(delegate ()
                    {
                        Thread.Sleep(2000);//timer for loading  loading de 1000ms (1 seg)
                        RunOnUiThread(() => { progressBar.Hide(); });
                        RunOnUiThread(() => { Toast.MakeText(this, "Acceso Exitoso", ToastLength.Long).Show();                      
                        });
                    })).Start();
                    //AppCargoExpress.UserServiceWebReference.UserService servicioUsuarios = new UserServiceWebReference.UserService();
                    //servicioUsuarios.GetUserAsync(user, pass);
                    //servicioUsuarios.GetUserCompleted += ServicioUsuarios_GetUserCompleted;
                  
                    new Thread(new ThreadStart(delegate ()
                    {
                        Thread.Sleep(2000);//timer for loading of 1000ms (1 seg)
                        RunOnUiThread(() => { progressBar.Hide(); });
                        RunOnUiThread(() => {
                        //Sending data to another Activity
                        //TODO: here add contection service for user validation
                        //if is correct then save the credencials in app
                        AuthService.SaveCredentials(user, pass);
                        Intent nextScreen = new Intent(this, typeof(LoginUserActivity));
                        nextScreen.PutExtra("userName", txtUserName.Text);
                        //here put the type of user, default value is 1
                        var typeOfUser = 1;
                        nextScreen.PutExtra("TypeOfUser", typeOfUser);
                            StartActivity(nextScreen);
                        });
                    })).Start();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void RegisterOnClick(Object sender, EventArgs e)
        {
            Intent nextScreen = new Intent(this, typeof(PreSelectRegisterActivity));
            StartActivity(nextScreen);
        }

        //private void Hombre_HelloWorldCompleted(object sender, hombre.HelloWorldCompletedEventArgs e)
        //{
        //    var hola = "hola";
        //}

        //private void ServicioUsuarios_GetUserCompleted(object sender, GetUserCompletedEventArgs e)//UserServiceWebReference.GetUserCompletedEventArgs e
        //{

        //    int a;

        //    a = 1;

        //    hombre.WebService1 b = new hombre.WebService1();

        //    int resp = b.HelloWorld(a);
        //    miUsuario = e.Result;

        //    if (miUsuario.Id_Usuario > 0)
        //    {
        //        new Thread(new ThreadStart(delegate ()
        //        {
        //            Thread.Sleep(1000);//espera para visualizar el loading de 1000ms (1 seg)
        //            RunOnUiThread(() => { progressBar.Hide(); });
        //            RunOnUiThread(() => { Toast.MakeText(this, "Acceso Exitoso", ToastLength.Long).Show(); });
        //        })).Start();
        //    }
        //    else
        //    {
        //        new Thread(new ThreadStart(delegate ()
        //        {
        //            Thread.Sleep(1000);//espera para visualizar el loading de 1000ms (1 seg)
        //            RunOnUiThread(() => { progressBar.Hide(); });
        //            RunOnUiThread(() => { Toast.MakeText(this, "usuario y/o contraseña incorrecta", ToastLength.Long).Show(); });
        //        })).Start();
        //    }


        //    BindUser();
        //}

        //private void BindUser()
        //{
        //    txtLogin.Text = miUsuario.Nick.ToString();
        //    txtPass.Text = miUsuario.Clave.ToString();
        //}
    }
}
