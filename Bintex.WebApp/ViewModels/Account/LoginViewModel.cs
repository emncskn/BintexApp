using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bintex.WebApp.ViewModels.Account
{
    public class LoginViewModel
    {
        [DataType(DataType.EmailAddress)]
        [Display(Name ="Mail Adresiniz", Prompt ="Email Adresi")]
        public string EmailAdress { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Şifreniz", Prompt = "Şifreniz")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
