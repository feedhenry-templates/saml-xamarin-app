using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helloworld_XamarinForms.Shared.Models
{
    public enum MenuType
    {
        About,
        Blog,
        Login
    }
    public class MainMenuItem : BaseModel
    {
        public MainMenuItem()
        {
            MenuType = MenuType.About;
        }
        public string Icon { get; set; }
        public MenuType MenuType { get; set; }
    }
}
