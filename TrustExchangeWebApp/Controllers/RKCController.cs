using ServiceLib.Contracts;
using ServiceLib.Contracts.DocService;
using ServiceLib.Contracts.StorageService.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrustExchangeWebApp.Controllers
{
    public class RKCController : Controller
    {
        // GET: RKC
        public ActionResult Index()
        {
            ViewBag.Pending = ServiceCore.docservice.getDocs(new GetDocContract() { State = EDocState.RKC_PENDING });
            ViewBag.Reject = ServiceCore.docservice.getDocs(new GetDocContract() { State = EDocState.RKC_REJECT });
            ViewBag.Approved = ServiceCore.docservice.getDocs(new GetDocContract() { State = EDocState.RKC_APPROVED });
            ViewBag.Delivered = ServiceCore.docservice.getDocs(new GetDocContract() { State = EDocState.RKC_DELIVERED });

            return View();
        }

        public ActionResult Reject(string id)
        {

            ServiceCore.docservice.Reject(id);
            return new JsonResult() { Data = "{}" };
        }
        public ActionResult Approve(string id)
        {
            ServiceCore.docservice.Approve(id);
            return new JsonResult() { Data = "{}" };
        }
        public ActionResult Deliver(string id)
        {
            ServiceCore.docservice.Deliver(id);
            return new JsonResult() { Data = "{}" };
        }
    }
}