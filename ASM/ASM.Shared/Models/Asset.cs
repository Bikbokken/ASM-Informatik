using System;
using System.ComponentModel.DataAnnotations;

namespace ASM.Shared.Models
{
    public class Asset
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Serial Number is required.")]
        [StringLength(50, ErrorMessage = "Serial Number cannot be longer than 50 characters.")]
        public string SerialNumber { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "Model cannot be longer than 100 characters.")]
        public string? Model { get; set; }

        [Required(ErrorMessage = "Purchase Date is required.")]
        public DateTime PurchaseDate { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Current Status is required.")]
        [StringLength(50, ErrorMessage = "Status cannot be longer than 50 characters.")]
        public string CurrentStatus { get; set; } = "Tilgængelig";

        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }

        public AssetCategory Category { get; set; } = default!;

        public int? LocationId { get; set; }
        public Location? Location { get; set; }

        public int? ResponsibleUserId { get; set; }
        public User? ResponsibleUser { get; set; }

        [StringLength(255, ErrorMessage = "QRCode cannot be longer than 255 characters.")]
        public string? QRCode { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        public ICollection<AssetStatusHistory> StatusHistories { get; set; } = new List<AssetStatusHistory>();
        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
        public ICollection<MaintenanceLog> MaintenanceLogs { get; set; } = new List<MaintenanceLog>();
    }
}
