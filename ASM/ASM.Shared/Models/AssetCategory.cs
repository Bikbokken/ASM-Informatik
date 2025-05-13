using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASM.Shared.Models
{
    public class AssetCategory
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(100, ErrorMessage = "Category name cannot be longer than 100 characters.")]
        public string Name { get; set; } = string.Empty;

        public int? ParentId { get; set; }

        public AssetCategory? Parent { get; set; }

        public ICollection<AssetCategory> Children { get; set; } = new List<AssetCategory>();
        public ICollection<Asset> Assets { get; set; } = new List<Asset>();
    }
}
