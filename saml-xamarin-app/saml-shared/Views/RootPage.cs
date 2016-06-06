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
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using saml_xamarin.Shared.Models;
using saml_xamarin.Shared.ViewModels;
using saml_xamarin.Shared.Views;

namespace saml_xamarin.Shared
{
    public class RootPage : MasterDetailPage
    {
        Dictionary<MenuType, NavigationPage> Pages { get; set; }

        public RootPage()
        {
            Pages = new Dictionary<MenuType, NavigationPage>();
            Master = new MenuPage(this);
            BindingContext = new BaseViewModel(this)
            {
                Title = "RHMAP",
                Icon = "slideout.png"
            };
            //setup home page
			NavigateAsync(MenuType.Login);
        }

        public async Task NavigateAsync(MenuType id)
        {
            Page newPage;
            if (!Pages.ContainsKey(id))
            {

                switch (id)
                {
                    case MenuType.About:
                        Pages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                    case MenuType.Blog:
                        Pages.Add(id, new NavigationPage(new BlogPage()));
                        break;
                    case MenuType.Login:
                        Pages.Add(id, new NavigationPage(new LoginPage()));
                        break;
                }
            }

            newPage = Pages[id];
            if (newPage == null)
                return;

            //pop to root for Windows Phone
            if (Detail != null && Device.OS == TargetPlatform.WinPhone)
            {
                await Detail.Navigation.PopToRootAsync();
            }

            Detail = newPage;

            if (Device.Idiom != TargetIdiom.Tablet)
                IsPresented = false;
        }
    }
}
