using ServiceLib.Contracts;
using System;
using System.Collections.Generic;
using ServiceLib.Contracts.DealService;
using ServiceLib.Contracts.StorageService;
using System.Linq;

namespace ServiceLib
{
    public class DealService : IDealService
    {
        IStorageService<TDeal> db { get; set; }
        public DealService(IStorageService<TDeal> srv)
        {
            db = srv;
        }
        public void AddDeal(AddDealContract r)
        {
            db.Set(new TDeal()
            {
                smartcontractaddr = r.smartcontractaddr,
                docid = r.docid,
                dt= r.dt,
                from = r.from,
                froma = r.froma,
               Id = r.Id,
               isactive= true,
               ownerbank = r.ownerbank,
               Sum = r.Sum,
              to= r.to,
              toa  =r.toa   

            });
        }

        public void CloseDeal(CloseDealContract request)
        {
            var deal = GetDealByDocId(request.docid);
            deal.isactive = false;
            db.Set(deal);
        }

        public IEnumerable<DealItemContract> GetDeals()
        {
            return db.GetAll<TDeal>().Select(c => new DealItemContract()
            {
                SmartContractAddr = c.smartcontractaddr,
                Account = c.toa,
                BankOwner = c.ownerbank,
                BankSender = c.from,
                Date = c.dt,
                IsActive = c.isactive,
                Sum = c.Sum
            });
        }

        public TDeal GetDealByDocId(string id)
        {
            return db.GetAll<TDeal>().Where(d => d.docid == id).FirstOrDefault();
        }

        public void updateDealIsClosedBySCaddr(string smartcontractaddr)
        {
            var deal = db.GetAll<TDeal>().Where(d => d.smartcontractaddr == smartcontractaddr).FirstOrDefault();
            deal.bcdealclosed = true;
            db.Set(deal);
        }
    }
}
