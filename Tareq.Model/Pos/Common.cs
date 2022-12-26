using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tareq.Model.Pos
{
    public class Common
    {
        public int IsActive { get; set; }
        public Nullable<DateTime> CreateDate { get; set; }=DateTime.Now;
        public string? CreateUser { get; set; } = Environment.UserName;
        public string? CreateDevice { get; set; } = Environment.MachineName;
        public string? UpdateUser { get; set; } = "";
        public Nullable<DateTime> UpdateDate { get; set; }        
        public string? UpdateDevice { get; set; }
        public int? Version { get; set; } = 1;
    }
}
