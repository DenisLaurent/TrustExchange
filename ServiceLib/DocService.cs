﻿using ServiceLib.Contracts;
using System;
using System.Collections.Generic;
using ServiceLib.Contracts.DocService;
using ServiceLib.Contracts.StorageService;
using System.Linq;
using ServiceLib.Contracts.StorageService.Enums;
using Newtonsoft.Json;

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
            var doc = new TDoc()
            {
                AccountNumberFrom = request.FromAcc,
                AccountNumberTo = request.ToAcc,
                BankStorage = request.OwnerBic,
                BicFrom = request.FromBic,
                BicTo = request.ToBic,
                DocDate = DateTime.Now,
                Id = Guid.NewGuid().ToString(),
                State = Contracts.StorageService.Enums.EDocState.RKC_PENDING,
                Sum = decimal.Parse(request.Sum),
                TransactionAddr = "N/A"

            };
            db.Set(doc);
            return doc.Id;
        }

        public IEnumerable<DocItemContract> getDocs(GetDocContract response)
        {
            return db.GetAll<TDoc>().Where(d => d.State == response.State).Select(b =>
            new DocItemContract()
            {
                 AccountNumberTo = b.AccountNumberTo,
                 State = b.State,
                 BankStorage = b.BankStorage,
                 AccountNumberFrom = b.AccountNumberFrom,
                 BicFrom = b.BicFrom,
                 BicTo =b.BicTo,
                 DocDate = b.DocDate,
                 Id = b.Id,
                 Sum = b.Sum,
                 TransactionAddr =b.TransactionAddr
            });
        }



        public void Reject(string id)
        {
            var d = db.Get(id);
            if(d.State == EDocState.RKC_PENDING)
            {
                d.State = EDocState.RKC_REJECT;
                db.Set(d);
            }
        }
        public void Approve(string id)
        {
            var d = db.Get(id);
            if (d.State == EDocState.RKC_PENDING)
            {
                d.State = EDocState.RKC_APPROVED;
                db.Set(d);

                ServiceCore.exchangeservice.CreateDoc(new Contracts.BlockChainExchangeService.CreateDocContract()
                {
                    BicFrom = d.BicFrom,
                    BicTo = d.BicTo,
                    DocOriginalId = d.Id,
                    DocSerialized = JsonConvert.SerializeObject(d)
                }
                );

            }
        }
        public void Deliver(string id)
        {
            var d = db.Get(id);
            if (d.State == EDocState.RKC_APPROVED)
            {
                d.State = EDocState.RKC_DELIVERED;
                db.Set(d);


                ServiceCore.dealservice.CloseDeal( new Contracts.DealService.CloseDealContract() {   })

                ServiceCore.exchangeservice.CloseDeal(new Contracts.BlockChainExchangeService.CloseDealContract()
                {
                      
                });
            }
        }
    }
}
