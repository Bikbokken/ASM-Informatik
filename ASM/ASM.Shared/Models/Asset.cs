using ASM.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM.Shared.Models
{
    public class Asset
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string SerialNumber { get; set; } = string.Empty;
        public string? Model { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal Price { get; set; }
        public string CurrentStatus { get; set; } = "Tilgængelig";

        public int CategoryId { get; set; }
        public AssetCategory Category { get; set; } = default!;

        public int? LocationId { get; set; }
        public Location? Location { get; set; }

        public int? ResponsibleUserId { get; set; }
        public User? ResponsibleUser { get; set; }

        public string? QRCode { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<AssetStatusHistory> StatusHistories { get; set; } = new List<AssetStatusHistory>();
        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
        public ICollection<MaintenanceLog> MaintenanceLogs { get; set; } = new List<MaintenanceLog>();
    }

}
