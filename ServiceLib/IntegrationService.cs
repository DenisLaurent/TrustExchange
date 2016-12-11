using ServiceLib.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLib.Contracts.IntegrationService;

namespace ServiceLib
{
    public class IntegrationService : IIntegrationService
    {
        public void DealClosed(DealClosedContract request)
        {
            throw new NotImplementedException();
        }

        public void DocClosed(DocClosedContract request)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// уведомление банка отправителя о том что докусент попал в БЧ, проставляем ему addr транзакции БЧ
        /// </summary>
        /// <param name="request"></param>
        public void DocCreated(DocCreatedContract request)
        {
            throw new NotImplementedException();
        }

        public void DocReceived(DocReceivedContract request)
        {
            throw new NotImplementedException();
        }
    }
}
