using ServiceLib.Contracts.DocService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLib.Contracts
{
    public interface IDocService
    {
        string addDoc(AddDocContract request);
        IEnumerable<DocItemContract> getDocs(GetDocContract response);
    }
}
