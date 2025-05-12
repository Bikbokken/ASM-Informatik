using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM.Shared.Models
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
        public ICollection<AssetStatusHistory> StatusChanges { get; set; } = new List<AssetStatusHistory>();
        public ICollection<MaintenanceLog> MaintenanceLogs { get; set; } = new List<MaintenanceLog>();
    }

}
