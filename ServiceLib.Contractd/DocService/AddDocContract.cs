using System;

namespace ServiceLib.Contracts.DocService
{
    public class AddDocContract
    {
        public string Id { get; set; }
        public string OwnerBic { get; set; }
        public string FromBic { get; set; }
        public string ToBic { get; set; }
        public string FromAcc { get; set; }
        public string ToAcc { get; set; }
        public string Sum { get; set; }
        public DateTime Date { get; set; }
    }
}
