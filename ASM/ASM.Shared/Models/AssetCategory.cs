using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM.Shared.Models
{
    public class AssetCategory
    {
         public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;

        public int? ParentId { get; set; }
        public AssetCategory? Parent { get; set; }

        public ICollection<AssetCategory> Children { get; set; } = new List<AssetCategory>();
        public ICollection<Asset> Assets { get; set; } = new List<Asset>();
    }

}
