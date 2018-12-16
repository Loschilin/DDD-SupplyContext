using System;
using SupplyContext.Domain.Common;
using SupplyContext.Domain.Entities;

namespace SupplyContext.Domain
{

    public class Supply : IAggregateRoot
    {
        public string Number { get; }
        public DateTime Date { get; }
        public string ContractorCode { get; }

        public SupplyList TitleList { get; private set; }

        public Supply(
            string number, 
            DateTime date, 
            string contractorCode)
        {
            Number = number;
            Date = date;
            ContractorCode = contractorCode;
        }

        public void WhenTitleBeScan(SupplyList titleList)
        {
            TitleList = titleList;
        }
    }
}
