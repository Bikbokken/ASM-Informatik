using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM.Shared.Models
{
    public class Role : IdentityRole<int>
    {
        public string Name { get; set; } = string.Empty;

        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }

}
