using System;
using System.Collections.Generic;

namespace PurchaseTracker.Api.Models
{
    public class PurchaseResponseModel
    {
        public PurchaseResponseModel()
        {
            PurchaseSummary = new PurchaseSummaryModel();
        }

        public List<PurchaseModel> Purchases { get; set; }
        public PurchaseSummaryModel PurchaseSummary { get; set; }
    }
}
