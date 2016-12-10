using ServiceLib.Contracts.DealService; 
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
        /// <summary>
        /// Получить список кредитных сделок по БИК банка
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        IEnumerable<DealItemContract> GetDeals(GetDealContract request);
        /// <summary>
        /// Закрыть кредитную сделку по факту получения денег из РКЦ
        /// </summary>
        /// <param name="request"></param>
        void CloseDeal(CloseDealContract request);
    }
}
