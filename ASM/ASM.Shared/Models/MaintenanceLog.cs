using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM.Shared.Models
{
    public class MaintenanceLog
    {
         public int Id { get; set; } 

        public int AssetId { get; set; }
        public Asset Asset { get; set; } = default!;

        public int PerformedBy { get; set; }
        public User User { get; set; } = default!;

        public DateTime PerformedAt { get; set; }
        public string Description { get; set; } = string.Empty;
    }

}
