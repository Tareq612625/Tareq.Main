using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tareq.Model
{
    public class SelectResult
    {
        public string Message { get; set; }
        public int Rows { get; set; }
        public bool Success { get; set; }
        public SelectResult(bool success,string message,int row)
        {
            Success = success;
            Message = message;
            Rows = 0;
        }
    }
}
