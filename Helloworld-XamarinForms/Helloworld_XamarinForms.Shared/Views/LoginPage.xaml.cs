using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Helloworld_XamarinForms.Shared.ViewModels;
using System.Threading.Tasks;

namespace Helloworld_XamarinForms.Shared.Views
{
    public partial class LoginPage : ContentPage
    {
        LoginViewModel loginModel;

        public LoginPage ()
        {
            InitializeComponent ();
            BindingContext = loginModel = new LoginViewModel(this);
            MyWebView.Navigated += (object sender, WebNavigatedEventArgs e) => 
            {
                if (e.Url.Contains("login/ok"))
                    ShowSignedIn();
            };
        }

        private async Task ShowSignedIn()
        {
           var success = await loginModel.ValidateSignIn ();
           if (success)
            SignIn.Text = "Signed In";
        }
    }
}

