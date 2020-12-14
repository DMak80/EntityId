using System;
using EntityIdLib.Uids;

namespace EntityIdLib.Converters.Impl
{
    public class LongUidConverter : UidConverter<long>
    {
        public LongUidConverter(string start) : base(start)
        {
        }

        private long? GetId(string? uid)
        {
            if ((uid?.StartsWith(Starts) ?? false)
                && uid.Length > Starts.Length
                && long.TryParse(uid.Substring(Starts.Length), out var i))
                return i;

            return null;
        }

        public override long FromUid(string? uid)
        {
            return GetId(uid) ?? throw new ArgumentOutOfRangeException(nameof(uid));
        }

        public override Uid ToUid(long key)
        {
            return new Uid($"{Starts}{key}");
        }
        
        public override Uid ToUid(object? key)
        {
            return ToUid(key is long b ? b : Convert.ToInt64(key));
        }
    }
}