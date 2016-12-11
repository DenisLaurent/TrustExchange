using ServiceLib.Contracts;
using ServiceLib.Contracts.IntegrationService;
using System.Web.Mvc;

namespace TrustExchangeWebApp.Controllers
{
    public class IntegrationsController : Controller
    {
        // GET: Integrations
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// БЧ оповещает отправителя платежа, что документ был зашит в БЧ и возвращает адрес его транзакции
        /// </summary>
        /// <returns></returns>
        public ActionResult DocCreated(string docid, string transactionaddr)
        {
           // ServiceCore.integrationservice.DocCreated(new DocCreatedContract() { docid = docid, transactionaddr = transactionaddr });
            return new JsonResult() { Data = "{}" };
        }
        /// <summary>
        /// БЧ оповещает получателя платежа, что документ был отправлен и сообщает адрес смарт контракта 
        /// </summary>
        /// <param name="doc_serialized"></param>
        /// <param name="smartcontractaddr"></param>
        /// <returns></returns>
        public ActionResult DocReceived(string doc_serialized, string smartcontractaddr)
        {
           // ServiceCore.integrationservice.DocReceived(new DocReceivedContract() { doc_serialized = doc_serialized, smartcontractaddr = smartcontractaddr });
            return new JsonResult() { Data = "{}" };
        }
        /// <summary>
        ///  БЧ оповещает банк который отправлял деньги, что банк получатель подтвердил получение денег
        /// </summary>
        /// <returns></returns>
        public ActionResult DocClosed(string transactionaddr)
        {
            //ServiceCore.integrationservice.DocClosed(new DocClosedContract() { transactionaddr = transactionaddr });
            return new JsonResult() { Data = "{}" };
        }
        /// <summary>
        /// БЧ оповещает банк который оформил кредит, что запрос на закрытие кредитной сделки  обработан
        /// </summary>
        /// <returns></returns>
        public ActionResult DealClosed(string smartcontractaddr)
        {
            //ServiceCore.integrationservice.DealClosed(new DealClosedContract() { smartcontractaddr = smartcontractaddr });
            return new JsonResult() { Data = "{}" };
        }

    }
}