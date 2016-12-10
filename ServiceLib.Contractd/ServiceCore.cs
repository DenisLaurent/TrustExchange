namespace ServiceLib.Contracts
{
    public static class ServiceCore
    {
        public static IBankService bankservice { get; set; }
        public static IDocService docservice { get; set; }
        public static IDealService dealservice { get; set; }
        public static IIntegrationService integrationservice { get; set; }
        public static ILogService logservice { get; set; }
        public static IBlockChainExchangeService exchangeservice { get; set; }
    }
}
