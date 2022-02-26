using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MonPCapplication.Models
{
    public class ClientRegistration
    {
        [Display(Name = "Username")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username obligatoire ")]
        public string username { get; set; }


        [Display(Name = "Nom")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nom obligatoire ")]
        public string nom { get; set; }


        [Display(Name = "Prenom")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Prénom obligatoire ")]
        public string prenom { get; set; }

        [Display(Name = "E-mail")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email obligatoire")]
        [DataType(DataType.EmailAddress)]
        public string mail { get; set; }

        [Display(Name = "Addresse")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Adresse obligatoire ")]
        public string adresse { get; set; }

        [Display(Name = "Telephone")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Telephone obligatoire ")]
        public string telephone { get; set; }

        [Display(Name = "Budget")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Budget obligatoire ")]
        public float Budget { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is est obligatoire")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum 6 characters required")]
        public string password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm password and password do not match")]
        public string Confirmpassword { get; set; }
    }
}