namespace ServiceLib.Contracts.BankService
{
    public class BankItemContract
    {
        public string Bic { get; set; }
        public string Name { get; set; }
        public bool IsTrustExchangeMember { get; set; }
    }
}
