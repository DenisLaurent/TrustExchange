using ServiceLib.Contracts.DocService; 
using System.Collections.Generic; 

namespace ServiceLib.Contracts
{
    public interface IDocService
    {
        string addDoc(AddDocContract request);
        IEnumerable<DocItemContract> getDocs(GetDocContract response);
        void Reject(string id);
        void Approve(string id);
        void Deliver(string id);
    }
}
