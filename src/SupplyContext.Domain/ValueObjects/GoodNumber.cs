using SupplyContext.Domain.Common;
using System;

namespace SupplyContext.Domain.ValueObjects
{
    public struct GoodNumber : IValueObject
    {
        public string Number { get; }

        public GoodNumber(string number)
        {
            Number = number;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is GoodNumber))
            {
                return false;
            }

            var number = (GoodNumber)obj;
            return Number == number.Number;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Number);
        }

        public static GoodNumber Parse(string input)
        {
            if (!TryParse(input, out var number))
            {
                throw new ApplicationException("Good number has wrong format");
            }

            return number;
        }

        public static bool TryParse(string input, out GoodNumber number)
        {
            number = new GoodNumber(input);
            return true;
        }

        public override string ToString()
        {
            return Number;
        }
    }
}