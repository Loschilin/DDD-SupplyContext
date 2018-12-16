using SupplyContext.Domain.Common;
using System;
using System.Collections.Generic;

namespace SupplyContext.Domain
{
    public struct SupplyBarCode : IValueObject
    {
        public BarCode Code { get; }

        public SupplyBarCode(BarCode code)
        {
            Code = code;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is SupplyBarCode))
            {
                return false;
            }

            var code = (SupplyBarCode)obj;
            return EqualityComparer<BarCode>.Default.Equals(Code, code.Code);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Code);
        }

        public override string ToString()
        {
            return $"sbc-{Code}";
        }

        public static SupplyBarCode Parse(string value)
        {
            if (!TryParse(value, out var result))
            {
                throw new ApplicationException("Wrong supply bar code format");
            }

            return result;
        }

        public static bool TryParse(string value, out SupplyBarCode code)
        {
            //validate and return false ...

            var barcode = new BarCode(value);
            code = new SupplyBarCode(barcode);
            return true;
        }
    }
}