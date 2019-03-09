using System;
using EntityIdLib.UIds;

namespace EntityIdLib.Converters.Impl
{
    public class GuidIdConverter : IdConverter<Guid>
    {
        public GuidIdConverter(string start) : base(start)
        {
        }

        private Guid? GetId(Uid uid)
        {
            if ((uid.Value?.StartsWith(Starts) ?? false)
                && uid.Value.Length > Starts.Length
                && Guid.TryParse(uid.Value.Substring(Starts.Length), out var i))
                return i;

            return null;
        }

        public override Guid FromUid(Uid uid)
        {
            return GetId(uid) ?? throw new ArgumentOutOfRangeException(nameof(uid));
        }

        public override Uid ToUid(Guid key)
        {
            return new Uid($"{Starts}{key}");
        }
    }
}