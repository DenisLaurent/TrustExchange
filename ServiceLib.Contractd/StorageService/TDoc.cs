using System;

namespace ServiceLib.Contracts.StorageService
{
    public class TDoc
    {
        public string BicFrom { get; set; }
        public string BicTo { get; set; }
        public decimal Sum { get; set; }
        public DateTime DocDate { get; set; }
        public string AccountNumberFrom { get; set; }
        public string AccountNumberTo { get; set; }
    }
}
