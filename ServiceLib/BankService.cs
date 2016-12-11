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
            db.Set(new TBank() { Id = request.Bic, Bic = request.Bic, IsTrustExchangeMember = true, Name = bankobject.Name });

         //   ServiceCore.exchangeservice.AddBank(new Contracts.BlockChainExchangeService.AddBankContract() { Bic = request.Bic, ApiHost = consts.webhost });
        }

        public void DelBank(DelBankContract request)
        {
            var bankobject = db.Get(request.Bic);
            db.Set(new TBank() { Id = request.Bic, Bic = request.Bic, IsTrustExchangeMember = false, Name = bankobject.Name });

          //  ServiceCore.exchangeservice.DropBank(new Contracts.BlockChainExchangeService.DropBankContract() { Bic = request.Bic });
        }

        public IEnumerable<BankItemContract> GetBanks()
        {
            return db.GetAll<TBank>().Select(b => new BankItemContract() { Bic = b.Bic, Name = b.Name, IsTrustExchangeMember = b.IsTrustExchangeMember }).ToList();
        }
    }
}
