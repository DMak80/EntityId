using System;
using EntityIdLib.UIds;

namespace EntityIdLib.Converters.Impl
{
    public class ShortIdConverter : IdConverter<short>
    {
        public ShortIdConverter(string start) : base(start)
        {
        }

        private short? GetId(Uid uid)
        {
            if ((uid.Value?.StartsWith(Starts) ?? false)
                && uid.Value.Length > Starts.Length
                && short.TryParse(uid.Value.Substring(Starts.Length), out var i))
                return i;

            return null;
        }

        public override short FromUid(Uid uid)
        {
            return GetId(uid) ?? throw new ArgumentOutOfRangeException(nameof(uid));
        }

        public override Uid ToUid(short key)
        {
            return new Uid($"{Starts}{key}");
        }
    }
}