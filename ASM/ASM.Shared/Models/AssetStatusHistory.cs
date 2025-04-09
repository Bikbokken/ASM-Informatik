using ASM.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM.Shared.Models
{
    public class AssetStatusHistory
    {
         public int Id { get; set; } 

        public Guid AssetId { get; set; }
        public Asset Asset { get; set; } = default!;

        public string Status { get; set; } = string.Empty;
        public int ChangedBy { get; set; }
        public User User { get; set; } = default!;
        public DateTime ChangedAt { get; set; }
        public string? Note { get; set; }
    }

}
