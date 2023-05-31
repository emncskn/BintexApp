using Bintex.Data.Entities.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bintex.Data
{
   public class BintexContext :IdentityDbContext<BintexUser,BintexRole,int>
    {
        public BintexContext(DbContextOptions o):base(o)
        {

        }
    }
}
