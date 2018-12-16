using SupplyContext.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace SupplyContext.Domain.ValueObjects
{
    public struct FileKey : IValueObject
    {
        public string Key { get; }

        public FileKey(string key)
        {
            Key = key;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is FileKey))
            {
                return false;
            }

            var key = (FileKey)obj;
            return Key == key.Key;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Key);
        }

        public override string ToString()
        {
            return Key;
        }

        public static FileKey Parse(string value)
        {
            if (!TryParse(value, out var result))
            {
                throw new ApplicationException("Wrong file key format");
            }

            return result;
        }

        public static bool TryParse(string value, out FileKey result)
        {
            //validate end return false if wrong

            result = new FileKey(value);
            return true;
        }
    }
}