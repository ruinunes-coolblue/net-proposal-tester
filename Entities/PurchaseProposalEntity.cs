﻿using System;
using System.Collections.Generic;
using System.Linq;

using net_coolblue_datastore_clients.RavenDb;

namespace PurchaseProposalTester.Entities
{
    public class PurchaseProposalEntity : IDocument<int>
    {
        public int ProductId { get; set; }
        public IEnumerable<int> ProductGroupIds { get; set; } = Enumerable.Empty<int>();
        public DateTime CreatedAt { get; set; }
        public bool Delivered { get; set; }
        public DateTime DeliveredAt { get; set; }
        public decimal StockInDays { get; set; }

        public bool Accepted { get; set; }
        public AcceptedDataEntity AcceptedData { get; set; }
        public int Id { get; set; }
    }
}