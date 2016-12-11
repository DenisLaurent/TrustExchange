using System;
using System.Linq;
using Renci.SshNet;
using ServiceLib.Contracts;
using ServiceLib.Contracts.BlockChainExchangeService;

namespace BlockChain.Integration
{
    public class BcAccess : IBlockChainExchangeService
    {

        //string account1 = "0xa2081622fcc99aec3c1efb575b548c90bdadf8cf";
        //string account2 = "0x052125e58ee311993185419d9323d4092fddc656";

        string userName = "deathys";
        string pass = "XSW@zaq1";

        string gethUrl = "http://localhost:8545";
        string hostUrl = "13.76.171.171";

        string creatorAddress = "0xe5855503e18317cfc775cf899f415ae60bce7189";
        string creatorAbiDefinition = "[{\"constant\":false,\"inputs\":[{\"name\":\"x\",\"type\":\"address\"}],\"name\":\"toString\",\"outputs\":[{\"name\":\"\",\"type\":\"string\"}],\"payable\":false,\"type\":\"function\"},{\"constant\":true,\"inputs\":[],\"name\":\"response\",\"outputs\":[{\"name\":\"\",\"type\":\"bytes\"}],\"payable\":false,\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"name\":\"id\",\"type\":\"uint256\"},{\"name\":\"_response\",\"type\":\"bytes\"}],\"name\":\"__tinyOracleCallback\",\"outputs\":[],\"payable\":false,\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"name\":\"acc\",\"type\":\"address\"},{\"name\":\"balance\",\"type\":\"uint256\"}],\"name\":\"addAccount\",\"outputs\":[{\"name\":\"balance2\",\"type\":\"uint256\"}],\"payable\":false,\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"name\":\"receiver\",\"type\":\"address\"},{\"name\":\"amount\",\"type\":\"uint256\"},{\"name\":\"callbackUrl\",\"type\":\"string\"}],\"name\":\"sendCoin\",\"outputs\":[{\"name\":\"sufficient\",\"type\":\"bool\"}],\"payable\":false,\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"name\":\"query\",\"type\":\"bytes\"}],\"name\":\"query\",\"outputs\":[],\"payable\":false,\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"name\":\"acc\",\"type\":\"address\"}],\"name\":\"getAccount\",\"outputs\":[{\"name\":\"balance\",\"type\":\"uint256\"}],\"payable\":false,\"type\":\"function\"},{\"inputs\":[],\"type\":\"constructor\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":false,\"name\":\"sender\",\"type\":\"address\"},{\"indexed\":false,\"name\":\"receiver\",\"type\":\"address\"},{\"indexed\":false,\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"CoinTransfer\",\"type\":\"event\"}]";
        string trackerAbiDefinition = "";

        class EthRpcRes
        {
            public string JsonRpc { get; set; }
            public int Id { get; set; }
            public string Result { get; set; }
        }

        class BcTransSendContratc
        {
            public string from { get; set; }
            public string to { get; set; }
            public string gas { get; set; }
            public string gasPrice { get; set; }
            public string value { get; set; }
            public string data { get; set; }
        }

        public string SendTransaction(string script)
        {
            try
            {
                using (var client = new SshClient(hostUrl, 22, userName, pass))
                {
                    client.Connect();

                    string filename = Guid.NewGuid().ToString().Substring(0, 5);

                    Func<string, string> toFile = (str) =>
                    {
                        return "echo '" + str.Replace("'", @"'\''") + "' >> ~/eth_data/" + filename;
                    };

                    Func<string, string> toFile2 = (str) =>
                    {
                        return "echo '" + str.Replace("'", @"'\''") + "' >> ~/eth_data/ex" + filename;
                    };

                    SshCommand comm = null;

                    var lines = script.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var line in lines)
                    {
                        comm = client.RunCommand(toFile(line));
                    }

                    comm = client.RunCommand($"cd eth_data/ && geth --exec 'loadScript(\"/home/huser/eth_data/{filename}\")' attach ipc:chains/devtest/geth.ipc");

                    client.Disconnect();

                    return comm.Result;
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        //public string SendTransaction(TransactionContract tx)
        //{
        //    var result =  SendTransaction("var token = web3.eth.contract([{\"constant\":false,\"inputs\":[{\"name\":\"x\",\"type\":\"address\"}],\"name\":\"toString\",\"outputs\":[{\"name\":\"\",\"type\":\"string\"}],\"payable\":false,\"type\":\"function\"},{\"constant\":true,\"inputs\":[],\"name\":\"response\",\"outputs\":[{\"name\":\"\",\"type\":\"bytes\"}],\"payable\":false,\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"name\":\"id\",\"type\":\"uint256\"},{\"name\":\"_response\",\"type\":\"bytes\"}],\"name\":\"__tinyOracleCallback\",\"outputs\":[],\"payable\":false,\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"name\":\"acc\",\"type\":\"address\"},{\"name\":\"balance\",\"type\":\"uint256\"}],\"name\":\"addAccount\",\"outputs\":[{\"name\":\"balance2\",\"type\":\"uint256\"}],\"payable\":false,\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"name\":\"receiver\",\"type\":\"address\"},{\"name\":\"amount\",\"type\":\"uint256\"},{\"name\":\"callbackUrl\",\"type\":\"string\"}],\"name\":\"sendCoin\",\"outputs\":[{\"name\":\"sufficient\",\"type\":\"bool\"}],\"payable\":false,\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"name\":\"query\",\"type\":\"bytes\"}],\"name\":\"query\",\"outputs\":[],\"payable\":false,\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"name\":\"acc\",\"type\":\"address\"}],\"name\":\"getAccount\",\"outputs\":[{\"name\":\"balance\",\"type\":\"uint256\"}],\"payable\":false,\"type\":\"function\"},{\"inputs\":[],\"type\":\"constructor\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":false,\"name\":\"sender\",\"type\":\"address\"},{\"indexed\":false,\"name\":\"receiver\",\"type\":\"address\"},{\"indexed\":false,\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"CoinTransfer\",\"type\":\"event\"}]).at(\"0xe5855503e18317cfc775cf899f415ae60bce7189\");"+
        //        $"var t = token.sendCoin.sendTransaction(\"{tx.Receiver.BcAccountNumber}\", 2, \"http://ethwebapp.azurewebsites.net/setstatus/{{hash}}\", {{from: \"{tx.Payer.BcAccountNumber}\"}});" + Environment.NewLine +
        //        "console.log(t);" + Environment.NewLine);
        //    tx.TransactionId = result.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).First(s => s.StartsWith("0x"));
        //    IOC.Resolve<IStorageService>().ReceiveTransaction(tx);
        //    return tx.TransactionId;
        //}

        public void CreateDoc(CreateDocContract request)
        {
            var result = SendTransaction("var token = web3.eth.contract(" + creatorAbiDefinition + ").at(\"" + creatorAddress + "\");" +
                $"var t = creator.createTransfer.sendTransaction(\"{request.BicFrom}\", \"{request.BicTo}\", \"{request.DocOriginalId}\", \"{request.DocSerialized}\", {{from: \"eth.accounts[0]\"}});" + Environment.NewLine +
                "console.log(t);" + Environment.NewLine);
            //tx.TransactionId = result.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).First(s => s.StartsWith("0x"));
        }

        public void CloseDeal(CloseDealContract request)
        {
            var result = SendTransaction("var token = web3.eth.contract(" + trackerAbiDefinition + ").at(\"" + request.smartcontractaddr + "\");" +
                $"var t = creator.CloseCreditDeal.sendTransaction({{from: \"eth.accounts[0]\"}});" + Environment.NewLine +
                "console.log(t);" + Environment.NewLine);
        }

        public void AddBank(AddBankContract request)
        {
            var result = SendTransaction("var token = web3.eth.contract(" + creatorAbiDefinition + ").at(\"" + creatorAbiDefinition + "\");" +
                $"var t = creator.AddBank.sendTransaction(\"{request.Bic}\", \"{request.ApiHost}\", {{from: \"eth.accounts[0]\"}});" + Environment.NewLine +
                "console.log(t);" + Environment.NewLine);
        }

        public void DropBank(DropBankContract request)
        {
            var result = SendTransaction("var token = web3.eth.contract(" + creatorAbiDefinition + ").at(\"" + creatorAbiDefinition + "\");" +
                $"var t = creator.RemoveBank.sendTransaction(\"{request.Bic}\", {{from: \"eth.accounts[0]\"}});" + Environment.NewLine +
                "console.log(t);" + Environment.NewLine);
        }
    }
}
