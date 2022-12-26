using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tareq.Model
{
    public class TransactionResult
    {
        public string Message { get; set; }
        public int Rows { get; set; }
        public bool Success { get; set; }
        public TransactionResult()
        {
            Success = true;
            Message = "Success";
            Rows = 0;
        }
    }
}
