using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tareq.Model.Pos
{
    public class AppUser : Common
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "User id")]
        [Required(ErrorMessage = "{0} is Required")]
        [StringLength(maximumLength: 20, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 1)]
        public string? UserId { get; set; }


        //// the mapped-to-column property 
        //public  string Password
        //{
        //    get;
        //    set;
        //}


        //[NotMapped]
        //public string PasswordD
        //{
        //    get{ return GetPasswordHash.Decrypt_Password(Password); }
        //    set { Password = GetPasswordHash.Encrypt_Password(value); }
        //}

        [Display(Name = "Password")]
        [Required(ErrorMessage = "{0} is Required")]
        [StringLength(maximumLength: 20, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 1)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "{0} is Required")]
        [StringLength(maximumLength: 100, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 1)]
        public string? UserName { get; set; }

        public int DepartmentId { get; set; }

        public int CompanyId { get; set; }


        [Display(Name = "Email")]
        [StringLength(maximumLength: 50, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 1)]
        public string? Email { get; set; }


        [Display(Name = "Phone")]
        [StringLength(maximumLength: 20, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 1)]
        public string? Phone { get; set; }


        [Display(Name = "Designation")]
        [StringLength(maximumLength: 100, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 1)]
        public string? Designation { get; set; }

    }
}
