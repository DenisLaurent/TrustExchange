using ServiceLib.Contracts;
using System;
using System.Collections.Generic;
using ServiceLib.Contracts.BankService;
using ServiceLib.Contracts.StorageService;
using System.Linq;

namespace ServiceLib
{
    public class BankService : IBankService
    {
        IStorageService<TBank> db { get; set; }
        public BankService(IStorageService<TBank> srv)
        {
            db = srv;
        }
        public void AddBank(AddBankContract request)
        {
            var bankobject = db.Get(request.Bic);
            db.Set(new TBank() { Id = request.Bic, Bic = request.Bic, IsTrustExchangeNumber = true, Name = bankobject.Name });
        }

        public void DelBank(DelBankContract request)
        {
            var bankobject = db.Get(request.Bic);
            db.Set(new TBank() { Id = request.Bic, Bic = request.Bic, IsTrustExchangeNumber = false, Name = bankobject.Name });
        }

        public IEnumerable<BankItemContract> GetBanks()
        {
            return db.GetAll<TBank>().Select(b => new BankItemContract() { Bic = b.Bic, Name = b.Name, IsTrustExchangeMember = b.IsTrustExchangeNumber });
        }
    }
}
