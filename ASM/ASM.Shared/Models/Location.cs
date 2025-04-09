using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM.Shared.Models
{
    public class Location
    {
         public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string? Address { get; set; }

        public ICollection<Asset> Assets { get; set; } = new List<Asset>();
    }

}
