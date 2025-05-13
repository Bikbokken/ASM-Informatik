using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASM.Shared.Models
{
    public class Location
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Location name is required.")]
        [StringLength(200, ErrorMessage = "Location name cannot be longer than 200 characters.")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Address cannot be longer than 500 characters.")]
        public string? Address { get; set; }

        public ICollection<Asset> Assets { get; set; } = new List<Asset>();
    }
}
