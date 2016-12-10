using ServiceLib.Contracts.BlockChainExchangeService; 

namespace ServiceLib.Contracts
{
    public interface IBlockChainExchangeService
    {
        void CreateDoc(CreateDocContract request);
        void CloseDeal(CloseDealContract request);
        void AddBank(AddBankContract request);
        void DropBank(DropBankContract request);
    }
}
