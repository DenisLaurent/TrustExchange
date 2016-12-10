using ServiceLib.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrustExchangeWebApp.Controllers
{
    public class DealController : Controller
    {
        // GET: Deal
        public ActionResult Index()
        {

            ViewBag.ActiveDeals = ServiceCore.dealservice.GetDeals().Where(d => d.IsActive).ToList();
            ViewBag.ClosedDeals = ServiceCore.dealservice.GetDeals().Where(d => !d.IsActive).ToList();
            return View();
        }
    }
}