using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM.Shared.Models
{
    public class Loan
    {
         public int Id { get; set; } 

        public int AssetId { get; set; }
        public Asset Asset { get; set; } = default!;

        public int UserId { get; set; }
        public User User { get; set; } = default!;

        public DateTime LoanedAt { get; set; }
        public DateTime? ExpectedReturnDate { get; set; }
        public DateTime? ReturnedAt { get; set; }
    }

}
