using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bintex.WebApp.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Display(Prompt ="Adınız")]
        public string Name { get; set; }
        [Display(Prompt = "Soyadınız")]
        public string Surname { get; set; }
        [Display(Prompt = "Mail Adresiniz")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Prompt = "Şifreniz")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Prompt = "Şifre Tekrar")]
        [DataType(DataType.Password)]
        public string ReTypePassword { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
