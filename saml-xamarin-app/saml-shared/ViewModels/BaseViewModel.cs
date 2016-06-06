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
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace saml_xamarin.Shared.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected Page FormsPage;

        public BaseViewModel(Page page)
        {
            this.FormsPage = page;
        }

        #region Public Properties
        private string title = string.Empty;
        public const string TitlePropertyName = "Title";
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private string subtitle = string.Empty;
        public const string SubtitlePropertyName = "Subtitle";
        public string Subtitle
        {
            get { return subtitle; }
            set { SetProperty(ref subtitle, value); }
        }

        private string icon = null;
        public const string IconPropertyName = "Icon";
        public string Icon
        {
            get { return icon; }
            set { SetProperty(ref icon, value); }
        }

        bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                if (SetProperty(ref isBusy, value))
                    IsNotBusy = !isBusy;
            }
        }

        bool isNotBusy = true;
        public bool IsNotBusy
        {
            get { return isNotBusy; }
            private set { SetProperty(ref isNotBusy, value); }
        }

        protected bool SetProperty<T>(
            ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;

            if (onChanged != null)
                onChanged();

            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
