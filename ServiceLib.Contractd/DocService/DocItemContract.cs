using ServiceLib.Contracts.StorageService.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLib.Contracts.DocService
{
    public class DocItemContract
    {
        public string Id { get; set; }
        public string BankStorage { get; set; }
        public string BicFrom { get; set; }
        public string BicTo { get; set; }
        public decimal Sum { get; set; }
        public DateTime DocDate { get; set; }
        public string AccountNumberFrom { get; set; }
        public string AccountNumberTo { get; set; }
        public EDocState State { get; set; }
        public string TransactionAddr { get; set; }
    }
}
