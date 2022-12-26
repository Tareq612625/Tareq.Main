using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tareq.Model.Pos
{
    public class TokenResponse
    {
        [Key]
        public string? JWTToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}
