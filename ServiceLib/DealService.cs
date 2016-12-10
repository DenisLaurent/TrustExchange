using ServiceLib.Contracts;
using System;
using System.Collections.Generic;
using ServiceLib.Contracts.DealService;

namespace ServiceLib
{
    public class DealService : IDealService
    {
        public void AddDeal(AddDealContract request)
        {
            throw new NotImplementedException();
        }

        public void CloseDeal(CloseDealContract request)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DealItemContract> GetDeals(GetDealContract request)
        {
            throw new NotImplementedException();
        }
    }
}
