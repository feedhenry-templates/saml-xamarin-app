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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using saml_xamarin.Shared.Models;
using saml_xamarin.Shared.ViewModels;

namespace saml_xamarin.Shared.Views
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
