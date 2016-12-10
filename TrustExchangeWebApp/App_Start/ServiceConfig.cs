using ServiceLib;
using ServiceLib.Contracts;
using ServiceLib.Contracts.StorageService;

namespace TrustExchangeWebApp 
{
    public static class ServiceConfig
    {
        public static void RegisterServices()
        {
            ServiceCore.dealservice = new DealService( new JSONFileStorageService<TDeal>("deal" ));
            ServiceCore.docservice = new DocService(new JSONFileStorageService<TDoc>("doc" ));
            ServiceCore.bankservice = new BankService(new JSONFileStorageService<TBank>("bank" ));
        }
    }
}