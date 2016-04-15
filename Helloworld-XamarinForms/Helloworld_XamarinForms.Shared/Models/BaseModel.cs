using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helloworld_XamarinForms.Shared.Models
{
    public class BaseModel
    {
        public BaseModel()
        {
        }

        public string Title { get; set; }
        public string Details { get; set; }
        public int Id { get; set; }

    }
}
