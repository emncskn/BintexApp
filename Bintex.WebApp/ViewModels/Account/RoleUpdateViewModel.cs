using System.ComponentModel.DataAnnotations;

namespace Bintex.WebApp.ViewModels.Account
{
    public class RoleUpdateViewModel
    {
        [Display(Name="Rol Adı")]
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public int Id { get; set; }
    }
}
