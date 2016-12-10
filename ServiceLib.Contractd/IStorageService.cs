using System.Collections.Generic; 

namespace ServiceLib.Contracts
{
    public interface IStorageService<T>
    {
        IEnumerable<T> GetAll<T>() ;
        bool Set<T>(T item);
        T Get(string id);
    }
}
