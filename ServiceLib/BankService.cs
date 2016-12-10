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
        IStorageService<TBank> bankstorage { get; set; }

        public void AddBank(AddBankContract request)
        {
            var bankobject = bankstorage.Get(request.Bic);
            bankstorage.Set(new TBank() { Bic = request.Bic, IsTrustExchangeNumber = true, Name = bankobject.Name });
        }

        public void DelBank(DelBankContract request)
        {
            var bankobject = bankstorage.Get(request.Bic);
            bankstorage.Set(new TBank() { Bic = request.Bic, IsTrustExchangeNumber = false, Name = bankobject.Name });
        }

        public IEnumerable<BankItemContract> GetBanks()
        {
            return bankstorage.GetAll<TBank>().Select(b => new BankItemContract() { Bic = b.Bic, Name = b.Name, IsTrustExchangeMember = b.IsTrustExchangeNumber });



            return new List<BankItemContract>()
            {
                new BankItemContract() { Bic ="1", IsTrustExchangeMember =false, Name = "bank A" },
                new BankItemContract() { Bic ="2", IsTrustExchangeMember =true, Name = "bank B" },
            };
        }
    }
}
