using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersRegistration.Models
{
    public class User:IdentityUser
    {
        public virtual string Name { get; set; }
        public virtual DateTimeOffset? LastLoginTime { get; set; }
        public virtual DateTimeOffset? RegistrationDate { get; set; }
        public virtual bool Block { get; set; }
    }
}
