using Microsoft.AspNetCore.Identity;
using System;

namespace homework_64_Atai.Models
{
    public class User : IdentityUser<int>
    {
        public String Avatar { get; set; }
        public String Role { get; set; }

    }
}
