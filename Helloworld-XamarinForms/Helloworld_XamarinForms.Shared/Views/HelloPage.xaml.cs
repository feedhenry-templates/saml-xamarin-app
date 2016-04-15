using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Helloworld_XamarinForms.Shared.ViewModels;

namespace Helloworld_XamarinForms.Shared.Views
{
    public partial class HelloPage : ContentPage
    {
        public HelloPage ()
        {
            InitializeComponent ();

            BindingContext = new HelloViewModel(this);
        }
    }
}

