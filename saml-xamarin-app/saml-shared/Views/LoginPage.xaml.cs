/**
 * Copyright Red Hat, Inc, and individual contributors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using saml_xamarin.Shared.ViewModels;
using System.Threading.Tasks;

namespace saml_xamarin.Shared.Views
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

