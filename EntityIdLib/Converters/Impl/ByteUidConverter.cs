using System;
using EntityIdLib.Uids;

namespace EntityIdLib.Converters.Impl
{
    public class ByteUidConverter : UidConverter<byte>
    {
        public ByteUidConverter(string start) : base(start)
        {
        }

        private byte? GetId(string? uid)
        {
            if ((uid?.StartsWith(Starts) ?? false)
                && uid.Length > Starts.Length
                && byte.TryParse(uid.Substring(Starts.Length), out var i))
                return i;

            return null;
        }

        public override byte FromUid(string? uid)
        {
            return GetId(uid) ?? throw new ArgumentOutOfRangeException($"Unknown prefix in arg {uid}");
        }

        public override Uid ToUid(byte key)
        {
            return new Uid($"{Starts}{key}");
        }

        public override Uid ToUid(object? key)
        {
            return ToUid(key is byte b ? b : Convert.ToByte(key));
        }
    }
}