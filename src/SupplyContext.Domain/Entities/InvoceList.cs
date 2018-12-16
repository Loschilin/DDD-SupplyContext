using SupplyContext.Domain.Common;
using SupplyContext.Domain.ValueObjects;

namespace SupplyContext.Domain.Entities
{
    public class InvoceList : IEntity, IList
    {
        public InvoiceBarCode BarCode { get; }
        public FileKey FileKey { get; }

        public InvoceList(InvoiceBarCode barCode, FileKey fileKey)
        {
            BarCode = barCode;
            FileKey = fileKey;
        }
    }
}