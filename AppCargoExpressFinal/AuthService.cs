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
        public static string UserName
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
                return (account != null) ? account.Properties["Password"] : null;
            }
        }

        public static void DeleteCredentials()
        {
            var account = AccountStore.Create().FindAccountsForService(Application.Context.ToString()).FirstOrDefault();
            if (account != null)
            {
                AccountStore.Create().Delete(account, Application.Context.ToString());
            }
        }

        public static void SaveCredentials(string userName, string password)
        {
            if (!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(password))
            {
                Account account = new Account
                {
                    Username = userName
                };
                account.Properties.Add("Password", password);
                AccountStore.Create(Application.Context).Save(account, Application.Context.ToString());
            }
        }
    
    }
}