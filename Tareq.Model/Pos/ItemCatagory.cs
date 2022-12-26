using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tareq.Model.Pos
{
    public class ItemCatagory :Common
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Catagory Id")]
        public int CatagoryId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "{0} is Required")]
        [StringLength(maximumLength: 100, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 1)]
        public string? CatagoryName { get; set; }

        [Display(Name = "Details")]
        [StringLength(maximumLength: 200, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 1)]
        public string? CatagoryDetails { get; set; }

        [Display(Name = "Image")]
        public string? CatagoryImage { get; set; }
    }
}
