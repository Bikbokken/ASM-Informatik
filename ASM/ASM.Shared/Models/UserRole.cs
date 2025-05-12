using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM.Shared.Models
{
    public class UserRole : IdentityUserRole<int>
    {

        public User User { get; set; } = default!;
        public Role Role { get; set; } = default!;
    }

}
