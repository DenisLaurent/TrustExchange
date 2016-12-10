using ServiceLib.Contracts;
using System;
using System.Collections.Generic;
using ServiceLib.Contracts.DocService;
using ServiceLib.Contracts.StorageService;

namespace ServiceLib
{
    public class DocService : IDocService
    {
        IStorageService<TDoc> db { get; set; }
        public DocService(IStorageService<TDoc> srv)
        {
            db = srv;
        }
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
