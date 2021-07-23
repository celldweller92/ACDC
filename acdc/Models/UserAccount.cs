using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ACDC.Models
{
    public class UserAccount
    {
        [Required(ErrorMessage = "First name is required!")]
        [Display(Name = "First name")]
        public string fname { get; set; }

        [Required(ErrorMessage = "Last name is required!")]
        [Display(Name = "Last name")]
        public string lname { get; set; }


        [Required(ErrorMessage = "Gender is required!")]
        [Display(Name = "Gender")]
        public string gender { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Username is required!")]
        [Display(Name = "Username")]
        public string user { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string pass { get; set; }

        [Required(ErrorMessage = "Confirm password is required!")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("pass", ErrorMessage = "'Confirm new password' and 'New password' do not match.")]
        public string compass { get; set; }
    }

    public class Login
    {
        [Required(ErrorMessage = "Username is required!")]
        [Display(Name = "Username")]
        public string user { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string pass { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
