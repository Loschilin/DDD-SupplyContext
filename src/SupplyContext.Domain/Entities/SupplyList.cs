using SupplyContext.Domain.Common;
using SupplyContext.Domain.ValueObjects;

namespace SupplyContext.Domain.Entities
{
    public class SupplyList : IEntity, IList
    {
        public SupplyList(SupplyBarCode barCode, FileKey fileKey)
        {
            BarCode = barCode;
            FileKey = fileKey;
        }

        public SupplyBarCode BarCode { get; }
        public FileKey FileKey { get; }
    }
}