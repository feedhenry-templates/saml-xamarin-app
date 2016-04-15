using System;
using System.Reflection;
using Xamarin.Forms;
using System.Threading.Tasks;
using FHSDK;
using System.Collections.Generic;
using System.Globalization;

namespace Helloworld_XamarinForms.Shared.ViewModels
{
    public class HelloViewModel : BaseViewModel
    {
        public HelloViewModel(Page page) : base(page)
        {
            IsBusy = false;
            ResponseMsg = "Response Here...";
        }

        private Command helloWorldCommand;

        public Command HelloWorldCommand
        {
            get { return helloWorldCommand ?? (helloWorldCommand = new Command(async () => await ExecuteHelloWorldCommand())); }
        }

        private async Task ExecuteHelloWorldCommand ()
        {
            try 
            {
                if (string.IsNullOrEmpty(Message))
                {
                        await FormsPage.DisplayAlert("Validation Error", "Please Enter Message", "Ok");
                        return;
                }

                IsBusy = true;
                var res = await FH.Cloud ("hello", "GET", null, new Dictionary<string, string> () { {
                        "hello",
                        Message
                    }
                });
                IsBusy = false;
                if (res.Error == null) 
                    ResponseMsg = (string)res.GetResponseAsDictionary () ["msg"];
                else
                {
                    await FormsPage.DisplayAlert("Service Error", res.Error.Message, "Ok");
                    return;
                }

            } catch (Exception ex) {
                await FormsPage.DisplayAlert ("Service Error", ex.Message, "Ok");    
            }
            
        }

        #region Properties
        private string message = string.Empty;
        public const string MessagePropertyName = "Message";
        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }

        private string responseMsg = string.Empty;
        public const string ResponseMsgPropertyName = "ResponseMsg";
        public string ResponseMsg
        {
            get { return responseMsg; }
            set { SetProperty(ref responseMsg, value); }
        }
        #endregion
    }
}


