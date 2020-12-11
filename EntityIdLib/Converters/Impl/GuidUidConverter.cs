using System;
using EntityIdLib.Uids;

namespace EntityIdLib.Converters.Impl
{
    public class GuidUidConverter : UidConverter<Guid>
    {
        public GuidUidConverter(string start) : base(start)
        {
        }

        private Guid? GetId(string uid)
        {
            if ((uid?.StartsWith(Starts) ?? false)
                && uid.Length > Starts.Length
                && Guid.TryParse(uid.Substring(Starts.Length), out var i))
                return i;

            return null;
        }

        public override Guid FromUid(string uid)
        {
            return GetId(uid) ?? throw new ArgumentOutOfRangeException(nameof(uid));
        }

        public override Uid ToUid(Guid key)
        {
            return new Uid($"{Starts}{key}");
        }
    }
}