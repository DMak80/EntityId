using System;
using EntityIdLib.Uids;

namespace EntityIdLib.Converters.Impl
{
    public class ShortUidConverter : UidConverter<short>
    {
        public ShortUidConverter(string start) : base(start)
        {
        }

        private short? GetId(string? uid)
        {
            if ((uid?.StartsWith(Starts) ?? false)
                && uid.Length > Starts.Length
                && short.TryParse(uid.Substring(Starts.Length), out var i))
                return i;

            return null;
        }

        public override short FromUid(string? uid)
        {
            return GetId(uid) ?? throw new ArgumentOutOfRangeException(nameof(uid));
        }

        public override Uid ToUid(short key)
        {
            return new Uid($"{Starts}{key}");
        }
        
        public override Uid ToUid(object? key)
        {
            return ToUid(key is short b ? b : Convert.ToInt16(key));
        }
    }
}