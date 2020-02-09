﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LabTestVerThree.Models
{
    public class UserViewModels
    {
    }
    public class CreateUserViewModel
    {
        // ...
    }

    public class LoginViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class RoleEditModel
    {
        public AppRole Role { get; set; }
        public IEnumerable<AppUser> Members { get; set; }
        public IEnumerable<AppUser> NonMembers { get; set; }
    }

    public class RoleModificationModel
    {
        [Required]
        public string RoleName { get; set; }
        public string[] IdsToAdd { get; set; }
        public string[] IdsToDelete { get; set; }
    }
}