using SupplyContext.Domain.Common;
using System;

namespace SupplyContext.Domain
{

    public struct BarCode : IValueObject
    {
        public string Code { get; }

        public BarCode(string code)
        {
            Code = code;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is BarCode))
            {
                return false;
            }

            var code = (BarCode)obj;
            return Code == code.Code;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Code);
        }

        public override string ToString()
        {
            return Code;
        }
    }
}