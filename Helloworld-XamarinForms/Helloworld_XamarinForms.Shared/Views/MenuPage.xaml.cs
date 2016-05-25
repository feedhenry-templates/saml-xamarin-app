
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Helloworld_XamarinForms.Shared.Models;
using Helloworld_XamarinForms.Shared.ViewModels;

namespace Helloworld_XamarinForms.Shared.Views
{
    public partial class MenuPage : ContentPage
    {
        RootPage root;
        List<MainMenuItem> menuItems;

        public MenuPage(RootPage root)
        {
            InitializeComponent();
            this.root = root;
  
            BackgroundColor = Color.FromHex("#03A9F4");
            ListViewMenu.BackgroundColor = Color.FromHex("#F5F5F5");

            BindingContext = new BaseViewModel(this)
            {
                Title = "Hello World Xamarin Forms",
                Subtitle = "Hello World Xamarin Forms",
                Icon = "slideout.png"
            };

            ListViewMenu.ItemsSource = menuItems = new List<MainMenuItem>
            {
                new MainMenuItem { Title = "Login", MenuType = MenuType.Login, Icon ="" },
                new MainMenuItem { Title = "About", MenuType = MenuType.About, Icon ="" },
                new MainMenuItem { Title = "Blog", MenuType = MenuType.Blog, Icon = "" }
            };

            ListViewMenu.SelectedItem = menuItems[0];

            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (ListViewMenu.SelectedItem == null)
                    return;

                await this.root.NavigateAsync(((MainMenuItem)e.SelectedItem).MenuType);
            };
        }
    }
}
