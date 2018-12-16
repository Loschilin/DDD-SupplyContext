using System.Collections.Generic;
using SupplyContext.Domain.Common;
using SupplyContext.Domain.Entities;
using SupplyContext.Domain.ValueObjects;

namespace SupplyContext.Domain.Aggregates
{
    public class Invoce : IAggregateRoot
    {
        public string SupplyNumber { get; }
        public string Number { get; }

        private readonly List<InvoceList> _lists = new List<InvoceList>();
        public IReadOnlyCollection<InvoceList> Lists  => _lists.AsReadOnly();

        // ReSharper disable once InconsistentNaming
        private List<GoodNumber> _goods { get; } = new List<GoodNumber>();
        public IReadOnlyCollection<GoodNumber> Goods => _goods;

        // ReSharper disable once ParameterTypeCanBeEnumerable.Local
        public Invoce(string supplyNumber, string number, IReadOnlyCollection<GoodNumber> goods)
        {
            SupplyNumber = supplyNumber;
            Number = number;
            _goods.AddRange(goods);
        }

        public void WhenListBeScan(InvoceList list)
        {
            _lists.Add(list);
        }
    }
}
