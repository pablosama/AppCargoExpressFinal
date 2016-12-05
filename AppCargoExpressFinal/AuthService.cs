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
using Xamarin.Auth;

namespace AppCargoExpressFinal
{
    public static class AuthService
    {
        public static string Alias
        {
            get
            {
                var account = AccountStore.Create().FindAccountsForService(Application.Context.ToString()).FirstOrDefault();
                return (account != null) ? account.Username : null;
            }
        }

        public static string Password
        {
            get
            {
                var account = AccountStore.Create().FindAccountsForService(Application.Context.ToString()).FirstOrDefault();
                return (account != null) ? account.Properties["Password"] :null;
            }
        }

        public static string Name
        {
            get
            {
                var account = AccountStore.Create().FindAccountsForService(Application.Context.ToString()).FirstOrDefault();
                return (account != null) ? account.Properties["Name"] : null;
            }
        }

        public static string UserType
        {
            get
            {
                var account = AccountStore.Create().FindAccountsForService(Application.Context.ToString()).FirstOrDefault();
                return (account != null) ? account.Properties["UserType"] : "0";
            }
        }

        public static string value
        {
            get
            {
                var account = AccountStore.Create().FindAccountsForService(Application.Context.ToString()).FirstOrDefault();
                return (account != null) ? account.Properties["Password"] : null;
            }
        }

        #region other data
        public static string LastName
        {
            get
            {
                var account = AccountStore.Create().FindAccountsForService(Application.Context.ToString()).FirstOrDefault();
                return (account != null) ? account.Properties["LastName"] : null;
            }
        }
        public static string PhoneNumber
        {
            get
            {
                var account = AccountStore.Create().FindAccountsForService(Application.Context.ToString()).FirstOrDefault();
                return (account != null) ? account.Properties["PhoneNumber"] : null;
            }
        }
        public static string CodArea
        {
            get
            {
                var account = AccountStore.Create().FindAccountsForService(Application.Context.ToString()).FirstOrDefault();
                return (account != null) ? account.Properties["CodArea"] : null;
            }
        }
        public static string Phone
        {
            get
            {
                var account = AccountStore.Create().FindAccountsForService(Application.Context.ToString()).FirstOrDefault();
                return (account != null) ? account.Properties["Phone"] : null;
            }
        }
        public static string Mail
        {
            get
            {
                var account = AccountStore.Create().FindAccountsForService(Application.Context.ToString()).FirstOrDefault();
                return (account != null) ? account.Properties["Mail"] : null;
            }
        }
        public static string Address
        {
            get
            {
                var account = AccountStore.Create().FindAccountsForService(Application.Context.ToString()).FirstOrDefault();
                return (account != null) ? account.Properties["Address"] : null;
            }
        }
        public static string City
        {
            get
            {
                var account = AccountStore.Create().FindAccountsForService(Application.Context.ToString()).FirstOrDefault();
                return (account != null) ? account.Properties["City"] : null;
            }
        }
        public static string LicenceNumber
        {
            get
            {
                var account = AccountStore.Create().FindAccountsForService(Application.Context.ToString()).FirstOrDefault();
                return (account != null) ? account.Properties["LicenceNumber"] : null;
            }
        }
        public static string TypOfVehicle
        {
            get
            {
                var account = AccountStore.Create().FindAccountsForService(Application.Context.ToString()).FirstOrDefault();
                return (account != null) ? account.Properties["TypOfVehicle"] : null;
            }
        }

        public static float Ranking
        {
            get
            {
                var account = AccountStore.Create().FindAccountsForService(Application.Context.ToString()).FirstOrDefault();
                return (account != null) ? float.Parse(account.Properties["Ranking"]) : 0f;
            }
        }

        public static int EvaluationsNumber
        {
            get
            {
                var account = AccountStore.Create().FindAccountsForService(Application.Context.ToString()).FirstOrDefault();
                return (account != null) ? int.Parse(account.Properties["EvaluationsNumber"]) : 0;
            }
        }
        #endregion

        public static void DeleteCredentials()
        {
            var account = AccountStore.Create().FindAccountsForService(Application.Context.ToString()).FirstOrDefault();
            if (account != null)
            {
                AccountStore.Create().Delete(account, Application.Context.ToString());
            }
        }

        public static void SaveCredentials(
            string alias,
            string password,
            string name,
            string lastName,
            string phoneNumber,
            string codArea,
            string phone,
            string mail,
            string address,
            string city,    
            int userType,
            int evaluationsNumber,
            string licenceNumber = "",
            string typOfVehicle = "",
            float ranking = 0)
        {
            if (!string.IsNullOrWhiteSpace(alias) && !string.IsNullOrWhiteSpace(password) && userType > 0)
            {
                Account account = new Account
                {
                    Username = alias
                };
                account.Properties.Add("Password", password);
                account.Properties.Add("Name", name);
                account.Properties.Add("LastName", lastName);
                account.Properties.Add("PhoneNumber", phoneNumber);
                account.Properties.Add("CodArea", codArea);
                account.Properties.Add("Phone", phone);
                account.Properties.Add("Mail", mail);
                account.Properties.Add("Address", address);
                account.Properties.Add("City", city);
                account.Properties.Add("UserType", userType.ToString());
                account.Properties.Add("LicenceNumber", licenceNumber);
                account.Properties.Add("TypOfVehicle", typOfVehicle);
                account.Properties.Add("Ranking", ranking.ToString());
                account.Properties.Add("EvaluationsNumber", evaluationsNumber.ToString());
                AccountStore.Create(Application.Context).Save(account, Application.Context.ToString());
            }
        }


        public static DataModels.DataModels.Usuario GetCredentials()
        {
            var usuario = new DataModels.DataModels.Usuario {
                alias = Alias,
                nombre = Name,
                apellido = LastName,
                contrasena = Password,
                telefonoMovil = PhoneNumber,
                telefonoFijo = Phone,
                codigoArea = CodArea,
                mail = Mail,
                direccion = Address,
                comuna = City,
                tipoUsuario = int.Parse(UserType),
                cantidadEvaluaciones = EvaluationsNumber,
                licenceNumber = LicenceNumber,
                typOfVehicle = TypOfVehicle,
                ranking = Ranking
            };

            return usuario;
        }

        public static void SaveCredentials(DataModels.DataModels.Usuario user)
        {
            if (!string.IsNullOrWhiteSpace(user.alias) && !string.IsNullOrWhiteSpace(user.contrasena) && user.tipoUsuario > 0)
            {
                Account account = new Account
                {
                    Username = user.alias
                };
                account.Properties.Add("Password", user.contrasena);
                account.Properties.Add("Name", user.nombre);
                account.Properties.Add("LastName", user.apellido);
                account.Properties.Add("PhoneNumber", user.telefonoMovil);
                account.Properties.Add("CodArea", user.codigoArea);
                account.Properties.Add("Phone", user.telefonoFijo);
                account.Properties.Add("Mail", user.mail);
                account.Properties.Add("Address", user.direccion);
                account.Properties.Add("City", user.comuna);
                account.Properties.Add("UserType", user.tipoUsuario.ToString());
                account.Properties.Add("LicenceNumber", user.licenceNumber);
                account.Properties.Add("TypOfVehicle", user.typOfVehicle);
                account.Properties.Add("Ranking", user.ranking.ToString());
                account.Properties.Add("EvaluationsNumber", user.cantidadEvaluaciones.ToString());
                AccountStore.Create(Application.Context).Save(account, Application.Context.ToString());
            }
        }

    }
}