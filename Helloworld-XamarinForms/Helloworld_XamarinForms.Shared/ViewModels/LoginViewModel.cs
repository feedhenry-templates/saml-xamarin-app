using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using FHSDK;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using FHSDK.Config;

namespace Helloworld_XamarinForms.Shared.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel (Page page) : base(page)
        {
            IsBusy = false;
        }

        #region Commands
        private Command loginCommand;

        public Command LoginCommand
        {
            get { return loginCommand ?? (loginCommand = new Command(async () => await ExecuteLoginCommand())); }
        }
        #endregion

        public async Task<Boolean> ValidateSignIn ()
        {
			var response = await FH.Cloud("sso/session/valid", "POST", null, GetRequestParams());
            if (response.Error == null)
            {
                var data = response.GetResponseAsDictionary();
                return true;
            }
            else
            {
                await FormsPage.DisplayAlert("Error", response.Error.ToString(), "Ok");
                return false;
            }
        }

        private async Task ExecuteLoginCommand ()
        {
            IsBusy = true;
			var response = await FH.Cloud ("sso/session/login_host", "POST", null, GetRequestParams ());

            var resData = response.GetResponseAsJObject ();
            var sso = (string)resData ["sso"];
            if (!string.IsNullOrEmpty (sso)) {
                source = sso;
                show = true;
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
}

