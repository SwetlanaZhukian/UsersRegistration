using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersRegistration.Models.ViewModels
{
    public class UsersViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTimeOffset? RegistrationDate { get; set; }
        public DateTimeOffset? LastLoginTime { get; set; }
        public bool IsBlock { get; set; }
        public bool IsChecked { get; set; }
      

    }
}
