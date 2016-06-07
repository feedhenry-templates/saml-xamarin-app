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
using Xamarin.Forms;
using System.Threading.Tasks;
using FHSDK;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using FHSDK.Config;

namespace saml_xamarin.Shared.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel (Page page) : base(page)
        {
            IsBusy = false;
			IsInitialized = false;
			Task.Run(async () => IsInitialized = await FHClient.Init());
        }
	
        #region Commands
        private Command loginCommand;

        public Command LoginCommand
        {
            get { return loginCommand ?? (loginCommand = new Command(async () => await ExecuteLoginCommand())); }
        }
        #endregion

		public async Task<LoggedInUser> ValidateSignIn ()
        {
			var response = await FH.Cloud("sso/session/valid", "POST", null, GetRequestParams());
            if (response.Error == null)
            {
                var data = response.GetResponseAsDictionary();
				return new LoggedInUser () 
				{
					Name = string.Format ("{0} {1}", data ["first_name"], data ["last_name"]),
					Email = (string)data ["email"],
					Expires = (DateTime)data ["expires"]
				};
            }
            else
            {
                await FormsPage.DisplayAlert("Error", response.Error.ToString(), "Ok");
                return null;
            }
        }

        private async Task ExecuteLoginCommand ()
        {
            IsBusy = true;
			var response = await FH.Cloud ("sso/session/login_host", "POST", null, GetRequestParams ());

            var resData = response.GetResponseAsJObject ();
			if (resData["error"] == null) 
			{
				var sso = (string)resData ["sso"];
				if (!string.IsNullOrEmpty (sso)) {
					Source = sso;
					Show = true;
				}
			} else 
			{
				await FormsPage.DisplayAlert("Error", resData["error"].ToString(), "Ok");
			}
			IsBusy = false; 
        }


        private static JObject GetRequestParams()
        {
            var data = new JObject();
			data.Add("token", FHConfig.GetInstance ().GetDeviceId ());
            return data;
        }

        #region Properties
		private bool isInitialized;
		//public const string IsInitializedPropertyName = "IsInitialized";
		public bool IsInitialized
		{
			get { return isInitialized; }
			set { SetProperty(ref isInitialized, value); }
		}
			
        private string source = string.Empty;
        public const string SourcePropertyName = "Source";
        public string Source
        {
            get { return source; }
            set { SetProperty(ref source, value); }
        }

        private bool show = false;
        public const string ShowPropertyName = "Show";
        public bool Show
        {
            get { return show; }
            set { SetProperty(ref show, value); }
        }
        #endregion

    }

	public class LoggedInUser 
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public DateTime Expires { get; set; }
	}
}

