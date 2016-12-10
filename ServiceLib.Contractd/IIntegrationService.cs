using ServiceLib.Contracts.IntegrationService; 

namespace ServiceLib.Contracts
{
    public interface IIntegrationService
    {
        void DocCreated(DocCreatedContract request);
        void DocReceived(DocReceivedContract request);
        void DocClosed(DocClosedContract request);
        void DealClosed(DealClosedContract request);
    }
}
