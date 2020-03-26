using System;

namespace PurchaseTracker.Api.Models
{
    public class PurchaseSummaryModel
    {
        public int TransactionCount { get; set; }
        public decimal AveragePurchaseAmount { get; set; }
        public decimal TotalPurchaseAmount { get; set; }
    }   
}
