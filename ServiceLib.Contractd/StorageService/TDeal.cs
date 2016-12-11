using System;

namespace ServiceLib.Contracts.StorageService
{
    public class TDeal
    {
        public bool bcdealclosed { get; set; }
        public string docid { get; set; }

        public DateTime dt { get; set; }
        public string from { get; set; }
        public string froma { get; set; }
        public string Id { get; set; }
        public bool isactive { get; set; }
        public string ownerbank { get; set; }
        public string smartcontractaddr { get; set; }
        public decimal Sum { get; set; }
        public string to { get; set; }
        public string toa { get; set; }
    }
}
