using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLib.Contracts.DealService
{
    public class AddDealContract
    {
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
