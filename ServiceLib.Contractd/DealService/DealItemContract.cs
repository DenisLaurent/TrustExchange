using System; 
namespace ServiceLib.Contracts.DealService
{
    public class DealItemContract
    {
        public string BankOwner { get; set; }
        public string BankSender { get; set; }
        public string Account { get; set; }
        public decimal Sum { get; set; }
        public DateTime Date { get; set; }
        public string SmartContractAddr { get; set; }
        public bool IsActive { get; set; }
    }
}
