using ServiceLib.Contracts.StorageService.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLib.Contracts.DocService
{
    public class GetDocContract
    {
        public EDocState State { get; set; }
    }
}
