using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using FHSDK.Droid;
using System.Threading.Tasks;
using Helloworld_XamarinForms.Shared;

namespace Helloworld_XamarinForms.Droid
{
    [Activity(Label = "Helloworld-XF", Icon = "@drawable/icon", MainLauncher = true,
        ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity 
    {
        protected override void OnCreate(Bundle bundle)
        {
            FormsAppCompatActivity.ToolbarResource = Resource.Layout.toolbar;
            FormsAppCompatActivity.TabLayoutResource = Resource.Layout.tabs;
            base.OnCreate(bundle);
            Forms.Init(this, bundle);
            LoadApplication(new App());
            InitFHClient();
        }

        private async Task InitFHClient ()
        {
            await Task.Run (() => {FHClient.Init(); });
        }
    }
}

