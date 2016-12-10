using ServiceLib;
using ServiceLib.Contracts;

namespace TrustExchangeWebApp 
{
    public static class ServiceConfig
    {
        public static void RegisterServices()
        {
            ServiceCore.dealservice = new DealService();
            ServiceCore.docservice = new DocService();
            ServiceCore.bankservice = new BankService();
        }
    }
}