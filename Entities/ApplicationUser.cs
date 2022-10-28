using System;
using Microsoft.AspNetCore.Identity;

namespace metaproapp.Entities
{
    public class ApplicationUser : IdentityUser
    {
       
        public string FirstName { get; set; }
        public string Lastname { get; set; }

    }
}
