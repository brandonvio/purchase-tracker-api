using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PurchaseTracker.Api.Models
{
    public class CategoryModel
    {
        [Key]
        public int CategoryId { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string CategoryName { get; set; }
    }
}
