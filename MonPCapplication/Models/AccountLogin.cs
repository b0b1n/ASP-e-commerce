using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MonPCapplication.Models
{
    public class AccountLogin
    {
        [Display(Name = "Username")]
        [Required(AllowEmptyStrings = false, ErrorMessage = " Le champs de 'Username' est obligatoire")]
        public string username { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = " Le champs de 'Password' est obligatoire")]
        [DataType(DataType.Password)]
        public string password { get; set; }


        [Display(Name = "Remember me ")]
        public bool RememberMe { get; set; }
        public static int est_connecté = 0;
        public static int id_connecté;
        public static int est_admin=0;

    }
}