﻿using net_coolblue_datastore_clients.RavenDb;

namespace PurchaseProposalTester.Entities
{
    public class ProductStockInformationEntity : IDocument<int>
    {
        public int AvailableStock { get; set; }
        public decimal WeeklySalesForecast { get; set; }
        public int PurchaseOrderQuantity { get; set; }
        public int PreparedToOrderQuantity { get; set; }
        public decimal ActiveMailConversion { get; set; }
        public int ContainerQuantity { get; set; }
        public int Id { get; set; }
    }
}