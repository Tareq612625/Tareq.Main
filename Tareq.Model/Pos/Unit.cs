using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tareq.Model.Pos
{
    public class Unit :Common
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Unit Id")]
        public int UnitId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "{0} is Required")]
        [StringLength(maximumLength: 20, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 1)]
        public string? UnitName { get; set; }

        [Display(Name = "Unit Conversion")]
        public decimal UnitConversion { get; set; } = 0;
    }
}
