using ServiceLib.Contracts;
using ServiceLib.Contracts.BankService; 
using System.Linq; 
using System.Web.Mvc;

namespace TrustExchangeWebApp.Controllers
{
    public class BankController : Controller
    {
        // GET: Bank
        public ActionResult Index()
        {

            ViewBag.TrustExchangeBankList = ServiceCore.bankservice.GetBanks().Where(b => b.IsTrustExchangeMember).ToList();
            ViewBag.BankList = ServiceCore.bankservice.GetBanks().Where(b => !b.IsTrustExchangeMember).ToList();

            return View();
        }

        public ActionResult Disconnect(string bic)
        {
            ServiceCore.bankservice.DelBank(new DelBankContract() { Bic = bic });
            return View();
        }

        public ActionResult Connect(string bic)
        {
            ServiceCore.bankservice.AddBank(new AddBankContract() { Bic = bic });
            return View();
        }
    }
}