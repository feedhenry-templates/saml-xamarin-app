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
			MyWebView.Navigated += async (object sender, WebNavigatedEventArgs e) => 
            {
				if (e.Url.Contains("login/ok")) 
				{
                    await ShowSignedIn();
				}
            };
        }

        private async Task ShowSignedIn()
        {
           var user = await loginModel.ValidateSignIn ();
			if (user != null) 
			{
				MyWebView.IsVisible = false;
				SignIn.IsVisible = false;
				SignedIn.IsVisible = true;

				Name.Text = user.Name;
				Email.Text = user.Email;
				Expires.Text = user.Expires.ToString ();
			}
        }
    }
}

