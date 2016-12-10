using ServiceLib.Contracts;
using ServiceLib.Contracts.DocService;
using System; 
using System.Web.Mvc;

namespace TrustExchangeWebApp.Controllers
{
    public class DocController : Controller
    {
        // GET: Doc
        public ActionResult Index()
        {
            ViewBag.Banks = ServiceCore.bankservice.GetBanks();
            return View();
        }
        /// <summary>
        /// создание платежки из интерфейса Интернет банк
        /// </summary>  
        public ActionResult Create(string from, string to, string accf, string acct, string sum)
        {

            ServiceCore.docservice.addDoc(
                new AddDocContract()
                {

                    OwnerBic = from,
                    Id = Guid.NewGuid().ToString(),
                    Date = DateTime.Now,
                    FromAcc = accf,
                    FromBic = from,
                    Sum = sum ,
                    ToAcc = acct,
                    ToBic = to
                });

            return new JsonResult() { Data = "{}" };
        }
    }
}