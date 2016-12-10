using ServiceLib.Contracts;
using System;
using System.Collections.Generic;
using ServiceLib.Contracts.DocService;

namespace ServiceLib
{
    public class DocService : IDocService
    {
        public string addDoc(AddDocContract request)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DocItemContract> getDocs(GetDocContract response)
        {
            throw new NotImplementedException();
        }
    }
}
