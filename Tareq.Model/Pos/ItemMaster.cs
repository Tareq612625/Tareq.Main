using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tareq.Model.Pos
{
    public class ItemMaster:Common
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Item Name")]
        public int ItemId { get; set; }


        [Display(Name = "Name")]
        [Required(ErrorMessage = "{0} is Required")]
        [StringLength(maximumLength: 100, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 1)]
        public string? ItemName { get; set; }


        [Display(Name = "Description")]
        [StringLength(maximumLength: 250, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 1)]
        public string? ItemDescription { get; set; }


        [Display(Name = "Catagory")]
        [Required(ErrorMessage = "{0} is Required")]
        public int CatagoryId { get; set; }
        [ForeignKey("CatagoryId")]
        public ItemCatagory? ItemCatagorys { get; set; }



        [Display(Name = "Unit")]
        [Required(ErrorMessage = "{0} is Required")]
        public int UnitId { get; set; }
        [ForeignKey("UnitId")]
        public Unit? Units { get; set; }


        [Display(Name = "Group")]
        public int GroupId { get; set; }
        [ForeignKey("GroupId")]
        public ItemGroup? ItemGroups { get; set; }


        [Display(Name = "Keyword")]
        [StringLength(maximumLength: 100, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 1)]
        public string? ItemKeyword { get; set; }


        [Display(Name = "Rate")]
        [Required(ErrorMessage = "{0} is Required")]
        public decimal ItemRate { get; set; }

        [Display(Name = "Image")]
        public string? ItemImage { get; set; }
    }
}
