using System;
using ServiceLib.Contracts;
using System.Collections.Generic;
using StackExchange.Redis.Extensions.Core;
using StackExchange.Redis;

namespace ServiceLib
{
    public class RedisStorage<T> : IStorageService<T>
    {
        public ICacheClient _client;
        protected static ConnectionMultiplexer _connection = null;
        IServer _server;
        static object _locker = new object();
        string key = "RedisStorageService";
        //private StorageContract _storageContract;

        public T Get(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll<T>()
        {
            throw new NotImplementedException();
        }

        public bool Set<T>(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> IStorageService<T>.GetAll<T>()
        {
            throw new NotImplementedException();
        }
    }
}
