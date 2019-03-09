using System;
using EntityIdLib.Uids;

namespace EntityIdLib.Converters.Impl
{
    public class LongIdConverter : IdConverter<long>
    {
        public LongIdConverter(string start) : base(start)
        {
        }

        private long? GetId(Uid uid)
        {
            if ((uid.Value?.StartsWith(Starts) ?? false)
                && uid.Value.Length > Starts.Length
                && long.TryParse(uid.Value.Substring(Starts.Length), out var i))
                return i;

            return null;
        }

        public override long FromUid(Uid uid)
        {
            return GetId(uid) ?? throw new ArgumentOutOfRangeException(nameof(uid));
        }

        public override Uid ToUid(long key)
        {
            return new Uid($"{Starts}{key}");
        }
    }
}