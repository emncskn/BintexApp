using System.ComponentModel.DataAnnotations;

namespace Bintex.WebApp.ViewModels.Account
{
    public class RoleAddViewModel
    {
        [Display(Name="Rol Adı")]
        public string Name { get; set; }
    }
}
