﻿using ServiceLib.Contracts.DealService;
using ServiceLib.Contracts.StorageService;
using System.Collections.Generic;

namespace ServiceLib.Contracts
{
    public interface IDealService
    {
        /// <summary>
        /// создается кредитная сделка при получении уведомления от БЧ
        /// </summary>
        /// <param name="request"></param>
        void AddDeal(AddDealContract request);
        void updateDealIsClosedBySCaddr(string smartcontractaddr);

        /// <summary>
        /// Получить список кредитных сделок
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        IEnumerable<DealItemContract> GetDeals();
        /// <summary>
        /// Закрыть кредитную сделку по факту получения денег из РКЦ
        /// </summary>
        /// <param name="request"></param>
        void CloseDeal(CloseDealContract request);
        TDeal GetDealByDocId(string id);
    }
}
