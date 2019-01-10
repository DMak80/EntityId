using System;

namespace EntityIdLib.Converters
{
    public class ByteIdConverter : IdConverter<byte>
    {
        public ByteIdConverter(string start) : base(start)
        {
        }

        private byte? GetId(UId uid)
        {
            if ((uid.Value?.StartsWith(Starts) ?? false)
                && uid.Value.Length > Starts.Length
                && byte.TryParse(uid.Value.Substring(Starts.Length), out var i))
                return i;

            return null;
        }

        public override bool IsValidUid(UId uid)
        {
            return GetId(uid).HasValue;
        }

        public override byte FromUid(UId uid)
        {
            return GetId(uid) ?? throw new ArgumentOutOfRangeException(nameof(uid));
        }

        public override UId ToUid(byte key)
        {
            return new UId($"{Starts}{key}");
        }
    }
}