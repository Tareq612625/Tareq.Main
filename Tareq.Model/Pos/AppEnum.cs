using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tareq.Model.Pos
{
    public class AppEnum
    {
        public enum ResultMessage
        {
            [Description("No Data Found")]
            Notfound ,
            [Description("Data Found")]
            Found
        }
    }
}
