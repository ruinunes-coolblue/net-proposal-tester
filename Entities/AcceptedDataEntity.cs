using System;

namespace PurchaseProposalTester.Entities
{
    public class AcceptedDataEntity
    {
        public int AcceptedSupplierId { get; set; }
        public decimal AcceptedPrice { get; set; }
        public int SuggestedQuantity { get; set; }
        public int AcceptedQuantity { get; set; }
        public string AcceptorUserName { get; set; }
        public DateTime AcceptedAt { get; set; }
    }
}