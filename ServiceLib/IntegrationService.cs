using ServiceLib.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLib.Contracts.IntegrationService;
using ServiceLib.Contracts.StorageService;

namespace ServiceLib
{
    public class IntegrationService : IIntegrationService
    {
        public void DealClosed(DealClosedContract request)
        {
            ServiceCore.dealservice.updateDealIsClosedBySCaddr(request.smartcontractaddr);
        }

        public void DocClosed(DocClosedContract request)
        {
            ServiceCore.docservice.notifyCreditDealClosed(request.transactionaddr);
        }
        /// <summary>
        /// уведомление банка отправителя о том что докусент попал в БЧ, проставляем ему addr транзакции БЧ
        /// </summary>
        /// <param name="request"></param>
        public void DocCreated(DocCreatedContract request)
        {
            ServiceCore.docservice.updateDocTranAddr(request.docid, request.transactionaddr);
        }

        public void DocReceived(DocReceivedContract request)
        {

            var docbytes = Convert.FromBase64String(request.doc_serialized);

            var jsondoc = Encoding.UTF8.GetString(docbytes);

            var d = Newtonsoft.Json.JsonConvert.DeserializeObject<TDoc>(jsondoc);

            ServiceCore.dealservice.AddDeal(new Contracts.DealService.AddDealContract() {
                  
                Id = Guid.NewGuid().ToString(),
                docid = d.Id,
                Sum = d.Sum,
                from = d.BicFrom,
                to = d.BicTo,
                froma = d.AccountNumberFrom,
                isactive = true,
                toa = d.AccountNumberTo,
                dt = d.DocDate,
                ownerbank = d.BicTo,
                smartcontractaddr =request.smartcontractaddr

            }); 
        }
    }
}
