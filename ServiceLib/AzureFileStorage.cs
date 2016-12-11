using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.File;
using Newtonsoft.Json;
using ServiceLib.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceLib
{
    public class AzureFileStorage<T> : IStorageService<T>
    {

        public string _dB { get; set; }
        public string _fileName { get; set; }
        private string _fileStorage;
        public T _ObjJson { get; set; }
        string idname;
        string fn;

        public AzureFileStorage(string filename)
        {
            _fileName = filename + ".json";
            _dB = GetDb(_fileName);
            _fileStorage = @"d:\share\" + _fileName;
            //_ObjJson = JsonConvert.DeserializeObject<T>(_dB);
            this.idname = "Id";
        }

        public T Get(string id)
        {
            var dB = GetDb(_fileName);
            string[] data = dB.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var d in data)
            {
                T inst = JsonConvert.DeserializeObject<T>(d);
                string idvalue = getid(inst);
                if (idvalue == id)
                    return inst;
            }
            throw new KeyNotFoundException(id);
        }


        string getid(object obj)
        {
            Type t = obj.GetType();
            var prop = t.GetProperty(idname);
            return prop.GetValue(obj).ToString();
        }

        private string GetDb(string fileName)
        {
            // Parse the connection string and return a reference to the storage account.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);

            // Create a CloudFileClient object for credentialed access to File storage.
            CloudFileClient fileClient = storageAccount.CreateCloudFileClient();

            // Get a reference to the file share we created previously.
            CloudFileShare share = fileClient.GetShareReference("storage");

            // Ensure that the share exists.
            if (share.Exists())
            {
                // Get a reference to the root directory for the share.
                CloudFileDirectory rootDir = share.GetRootDirectoryReference();

                //// Get a reference to the directory we created previously.
                //CloudFileDirectory sampleDir = rootDir.GetDirectoryReference("CustomLogs");

                //// Ensure that the directory exists.
                //if (sampleDir.Exists())
                {
                    // Get a reference to the file we created previously.
                    CloudFile file = rootDir.GetFileReference(fileName);

                    // Ensure that the file exists.
                    if (file.Exists())
                    {
                        // Write the contents of the file to the console window.
                        //Console.WriteLine(file.DownloadTextAsync().Result);
                        return file.DownloadTextAsync().Result;
                    }
                }
            }
            throw new InvalidOperationException("GetDb error");
        }

        public IEnumerable<T> GetAll<T>()
        {
            var dB = GetDb(_fileName);
            string[] data = dB.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var d in data)
            {
                T inst = JsonConvert.DeserializeObject<T>(d);
                yield return inst;
            }
        }

        private static T FromJSON<T>(string src)
        {
            return JsonConvert.DeserializeObject<T>(src);
        }
        private static string ToJSON(object src)
        {
            return src == null ? "{}" : JsonConvert.SerializeObject(src, Formatting.Indented);
        }

        public void Dispose()
        {
            //lock (_syncObject)
            _sincker.WaitOne();
            {
                bool useAzure = bool.Parse(ConfigurationManager.AppSettings["useAzure"]);

                if (useAzure)
                    SetDb(ToJSON(this));
                else
                    File.WriteAllText(_fileStorage, ToJSON(this));
            }
            _sincker.ReleaseMutex();
        }

        private void SetDb(string data)
        {
            // Parse the connection string and return a reference to the storage account.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);

            // Create a CloudFileClient object for credentialed access to File storage.
            CloudFileClient fileClient = storageAccount.CreateCloudFileClient();

            // Get a reference to the file share we created previously.
            CloudFileShare share = fileClient.GetShareReference("storage");

            // Ensure that the share exists.
            if (share.Exists())
            {
                // Get a reference to the root directory for the share.
                CloudFileDirectory rootDir = share.GetRootDirectoryReference();

                //// Get a reference to the directory we created previously.
                //CloudFileDirectory sampleDir = rootDir.GetDirectoryReference("CustomLogs");

                //// Ensure that the directory exists.
                //if (sampleDir.Exists())
                {
                    // Get a reference to the file we created previously.
                    CloudFile file = rootDir.GetFileReference(_fileName);

                    // Ensure that the file exists.
                    if (file.Exists())
                    {
                        // Write the contents of the file to the console window.
                        //Console.WriteLine(file.DownloadTextAsync().Result);
                        file.UploadTextAsync(data);
                    }
                }
            }
            //throw new InvalidOperationException("SetDb error");
        }

        public static Mutex _sincker = new Mutex(false, "finance");

        public bool Set<T>(T item)
        {
            List<T> items = new List<T>();
            var dB = GetDb(_fileName);
            string[] data = dB.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            items = GetAll<T>().ToList();
            items = items.Where(t => getid(t) != getid(item)).ToList();
            List<string> datalines = new List<string>();

            foreach (var e in items)
            {
                datalines.Add(JsonConvert.SerializeObject(e));
            }

            datalines.Add(JsonConvert.SerializeObject(item));
            SetDb(string.Join("\n", datalines));
            return true;
        }
    }
}
