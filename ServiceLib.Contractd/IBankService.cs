using ServiceLib.Contracts.BankService;
using System.Collections.Generic;

namespace ServiceLib.Contracts
{
    public interface IBankService
    {
        void AddBank(AddBankContract request);
        void DelBank(DelBankContract request);
        IEnumerable<BankItemContract> GetBanks();
    }
}
