using System;
using System.Collections.Generic;
using SupplyContext.Domain.Common;

namespace SupplyContext.Domain
{
    public struct InvoiceBarCode : IValueObject
    {
        public InvoiceBarCode(BarCode code)
        {
            Code = code;
        }

        public BarCode Code { get; }

        public override bool Equals(object obj)
        {
            if (!(obj is InvoiceBarCode))
            {
                return false;
            }

            var code = (InvoiceBarCode)obj;
            return EqualityComparer<BarCode>.Default.Equals(Code, code.Code);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Code);
        }

        public static InvoiceBarCode Parse(string input)
        {
            if (!TryParse(input, out var code))
            {
                throw new ApplicationException("Wrond bar code");
            }

            return code;
        }

        public static bool TryParse(string input, out InvoiceBarCode result)
        {
            var code = new BarCode(input);
            result = new InvoiceBarCode(code);
            return true;
        }

        public override string ToString()
        {
            return Code.ToString();
        }
    }
}