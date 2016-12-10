using Newtonsoft.Json;
using ServiceLib.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq; 

namespace ServiceLib
{
    public class JSONFileStorageService<T> : IStorageService<T>
    {
        string fn;
        string idname;
        public JSONFileStorageService(string filename )
        {
            fn = Path.Combine("D:\\TrustExchange", fn + ".json");
            this.idname = "Id";
        }

        string getid<T>(T obj)
        {
            Type t = typeof(T);
            var prop = t.GetProperty(idname);
            return prop.GetValue(obj).ToString();
        }

        public T Get(string id)
        {
            if (File.Exists(fn))
            {
                string[] data = File.ReadAllLines(fn);
                foreach (var d in data)
                {
                    T inst = JsonConvert.DeserializeObject<T>(d);
                    string idvalue = getid(inst);
                    if (idvalue == id)
                        return inst;
                }
                throw new KeyNotFoundException(id);
            }
            else
                throw new FileNotFoundException(fn);

        }

        public IEnumerable<T> GetAll<T>()
        {

            if (File.Exists(fn))
            {
                string[] data = File.ReadAllLines(fn);
                foreach (var d in data)
                {
                    T inst = JsonConvert.DeserializeObject<T>(d);
                    yield return inst;
                }
            } 
        }

        public bool Set<T>(T item)
        {
            string[] data = File.ReadAllLines(fn);
            List<T> items = GetAll<T>().ToList();
            items  = items.Where(t => getid<T>(t) != getid<T>(item)).ToList();
            List<string> datalines = new List<string>();

            foreach(var e in items)
            {
                datalines.Add(JsonConvert.SerializeObject(e));
            }

            datalines.Add(JsonConvert.SerializeObject(item));

            return true;
        }
    }
}
