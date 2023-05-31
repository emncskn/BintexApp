using AutoMapper;
using Bintex.Data.Entities.Account;
using Bintex.WebApp.ViewModels.Account;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Bintex.WebApp.Mapper
{
    public class BintexProfile:Profile
    {
        public BintexProfile()
        {
            CreateMap<BintexRole, RoleListViewModel>();

            
        }
    }
}
