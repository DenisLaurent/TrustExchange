using ServiceLib.Contracts;
using System;
using System.Collections.Generic;
using ServiceLib.Contracts.DealService;
using ServiceLib.Contracts.StorageService;

namespace ServiceLib
{
    public class DealService : IDealService
    {
        IStorageService<TDeal> db { get; set; }
        public DealService(IStorageService<TDeal> srv)
        {
            db = srv;
        }
        public void AddDeal(AddDealContract request)
        {
            throw new NotImplementedException();
        }

        public void CloseDeal(CloseDealContract request)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DealItemContract> GetDeals()
        {
            throw new NotImplementedException();
        }
    }
}
