using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bintex.Data.Entities.Account
{
    public class BintexUser:IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentityNumber { get; set; }
        public string ProfileImage { get; set; }
        public DateTime BirthDate { get; set; }
        public string SchoolName { get; set; }
        public Educations EducationStatus { get; set; }
        public Genders GenderCode { get; set; }
    }
}
