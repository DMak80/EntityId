using System;
using EntityIdLib.Uids;

namespace EntityIdLib.Converters.Impl
{
    public class ByteIdConverter : IdConverter<byte>
    {
        public ByteIdConverter(string start) : base(start)
        {
        }

        private byte? GetId(Uid uid)
        {
            if ((uid.Value?.StartsWith(Starts) ?? false)
                && uid.Value.Length > Starts.Length
                && byte.TryParse(uid.Value.Substring(Starts.Length), out var i))
                return i;

            return null;
        }

        public override byte FromUid(Uid uid)
        {
            return GetId(uid) ?? throw new ArgumentOutOfRangeException($"Unknown prefix in arg {uid.Value}");
        }

        public override Uid ToUid(byte key)
        {
            return new Uid($"{Starts}{key}");
        }
    }
}