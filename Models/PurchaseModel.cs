using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace PurchaseTracker.Api.Models
{
    public class PurchaseModel
    {
        [Key]
        public int PurchaseId { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string PayeeName { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal PurchaseAmount { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Memo { get; set; }
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }
    }
}
