namespace ServiceLib.Contracts.StorageService
{
    public class TBank
    {
        public string Id { get; set; }
        public string Bic { get; set; }
        public string Name { get; set; }
        public bool IsTrustExchangeNumber { get; set; }
    }
}
