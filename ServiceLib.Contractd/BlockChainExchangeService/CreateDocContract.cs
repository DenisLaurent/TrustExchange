namespace ServiceLib.Contracts.BlockChainExchangeService
{
    public class CreateDocContract
    {
        public string BicFrom { get; set; }
        public string BicTo { get; set; }
        public string DocSerialized { get; set; }
        public string DocOriginalId { get; set; }
    }
}
